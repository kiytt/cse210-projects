using System;
using System.Collections.Generic;

public class Validate // partially rewritten
{
    private List<Particle> _initialParticles;
    private List<Particle> _finalParticles;

    public Validate(string initial, string final)
    {
        _initialParticles = ParseParticleString(initial);
        _finalParticles = ParseParticleString(final);
    }

    public List<Particle> ParseParticleString(string input)
    {
        string[] names = input.Split(' ');
        List<Particle> particles = new List<Particle>();
        ParticleDatabase db = new ParticleDatabase();

        foreach (string name in names)
        {
            string cleanName = name.Trim();
            if (cleanName.Length > 0)
            {
                List<string> matches = db.Find("name", cleanName);
                if (matches.Count > 0)
                {
                    string rawLine = matches[0];
                    Particle p = CreateParticleFromRawLine(rawLine);
                    if (p != null) particles.Add(p);
                }
            }
        }
        return particles;
    }

    private Particle CreateParticleFromRawLine(string line)
    {
        string classification = "";
        foreach (string pair in line.Split(','))
        {
            string[] kv = pair.Split(':');
            if (kv.Length == 2 && kv[0].Trim().ToLower() == "classification")
            {
                classification = kv[1].Trim().ToLower();
                break;
            }
        }

        if (classification == "quark")
        {
            return new Quark(line);
        }
        else if (classification == "lepton")
        {
            return new Lepton(line);
        }
        else if (classification == "baryon")
        {
            return new Baryon(line);
        }
        else if (classification == "meson")
        {
            return new Meson(line);
        }
        else if (classification == "gauge_boson" || classification == "gaugeboson")
        {
            return new GaugeBoson(line);
        }
        else if (classification == "scalar_boson" || classification == "scalarboson")
        {
            return new ScalarBoson(line);
        }
        return null; // apparently is not none
    }

        public bool ContainsParticle(List<Particle> particles, string particleType)
    {
        foreach (Particle p in particles)
        {
            string name = p.GetName();
            
            if (particleType == "photon" && (name == "photon" || name == "γ"))
            {
                return true;
            }
            if (particleType == "lepton" && p is Lepton)
            {
                return true;
            }
            if (particleType == "neutrino" && name.Contains("neutrino"))
            {
                return true;
            }
        }
        return false;
    }

    public string MediatingForce()
    {
        double chargeI = 0, chargeF = 0;
        int baryNumI = 0, baryNumF = 0;
        int leptNumI = 0, leptNumF = 0;

        int upI = 0, downI = 0, charmI = 0, strangeI = 0, topI = 0, bottomI = 0;
        int upF = 0, downF = 0, charmF = 0, strangeF = 0, topF = 0, bottomF = 0;

        foreach (Particle p in _initialParticles)
        {
            chargeI += p.GetCharge();
            baryNumI += p.GetBaryonNumber();
            leptNumI += p.GetLeptonNumber();
            upI += p.GetUpNum();
            downI += p.GetDownNum();
            charmI += p.GetCharm();
            strangeI += p.GetStrangeness();
            topI += p.GetTopness();
            bottomI += p.GetBottomness();
        }

        foreach (Particle p in _finalParticles)
        {
            chargeF += p.GetCharge();
            baryNumF += p.GetBaryonNumber();
            leptNumF += p.GetLeptonNumber();
            upF += p.GetUpNum();
            downF += p.GetDownNum();
            charmF += p.GetCharm();
            strangeF += p.GetStrangeness();
            topF += p.GetTopness();
            bottomF += p.GetBottomness();
        }

        bool flavorsConserved = (upI == upF) && (downI == downF) && 
                                (charmI == charmF) && (strangeI == strangeF) && 
                                (topI == topF) && (bottomI == bottomF);

        if (Math.Abs(chargeI - chargeF) < 1e-5 && baryNumI == baryNumF && leptNumI == leptNumF)
        {
            if (ContainsParticle(_initialParticles, "photon") || ContainsParticle(_finalParticles, "photon"))
            {
                return "Electromagnetic";
            }
            else
            {
                if (flavorsConserved)
                {
                    if (ContainsParticle(_initialParticles, "neutrino") || ContainsParticle(_finalParticles, "neutrino"))
                    {
                        return "Weak";
                    }
                    else
                    {
                        if (ContainsParticle(_initialParticles, "lepton") || ContainsParticle(_finalParticles, "lepton"))
                        {
                            return "Likely electromagnetic, can be neutral weak";
                        }
                        else
                        {
                            return "Likely strong, can be neutral weak";
                        }
                    }
                }
                else
                {
                    return "Charged weak";
                }
            }
        }
        else
        {
            return "Forbidden";
        }
    }
}