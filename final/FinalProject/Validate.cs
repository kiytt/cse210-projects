using System;
using System.Collections.Generic;

public class Validate
{
    private ParticleDatabase _db = new ParticleDatabase();

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
                List<Particle> matches = db.Find("name", cleanName);
                if (matches.Count > 0)
                {
                    particles.Add(matches[0]);
                }
                else
                {
                    Particle newP = db.PromptAndAdd(cleanName);
                    if (newP != null)
                    {
                        particles.Add(newP);
                    }
                }
            }
        }
        return particles;
    }

        public bool ContainsParticle(List<Particle> particles, string particleType)
    {
        foreach (Particle p in particles)
        {
            string name = p.GetName();
            
            if (particleType == "photon" && (name == "photon"))
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

    private (double charge, double baryon, int lepton, int up, int down, int charm, int strange, int top, int bottom) 
    AggregateParticles(List<Particle> particles)
    {
        double charge = 0, baryon = 0;
        int lepton = 0, up = 0, down = 0, charm = 0, strange = 0, top = 0, bottom = 0;

        foreach (Particle p in particles)
        {
            charge += p.GetCharge();
            baryon += p.GetBaryonNumber();
            lepton += p.GetLeptonNumber();
            up += p.GetUpNum();
            down += p.GetDownNum();
            charm += p.GetCharm();
            strange += p.GetStrangeness();
            top += p.GetTopness();
            bottom += p.GetBottomness();
        }

        return (charge, baryon, lepton, up, down, charm, strange, top, bottom);
    }

    public string MediatingForce(string initialInput, string finalInput)
    {
        string interaction = "";
        List<Particle> initialParticles = ParseParticleString(initialInput);
        List<Particle> finalParticles = ParseParticleString(finalInput);

        var initial = AggregateParticles(initialParticles);
        var final = AggregateParticles(finalParticles);

        bool flavorsConserved = (initial.up == final.up) && (initial.down == final.down) && 
                                (initial.charm == final.charm) && (initial.strange == final.strange) && 
                                (initial.top == final.top) && (initial.bottom == final.bottom);

        if (Math.Abs(initial.charge - final.charge) < 1e-5 && 
            initial.baryon == final.baryon && 
            initial.lepton == final.lepton)
        {
            if (ContainsParticle(initialParticles, "photon") || ContainsParticle(finalParticles, "photon"))
            {
                interaction = "electromagnetic";
            }
            else
            {
                if (flavorsConserved)
                {
                    if (ContainsParticle(initialParticles, "neutrino") || ContainsParticle(finalParticles, "neutrino"))
                    {
                        interaction = "weak";
                    }
                    else
                    {
                        if (ContainsParticle(initialParticles, "lepton") || ContainsParticle(finalParticles, "lepton"))
                        {
                            interaction = "likely electromagnetic, can be neutral weak";
                        }
                        else
                        {
                            interaction = "likely strong, can be neutral weak";
                        }
                    }
                }
                else
                {
                    interaction = "charged weak";
                }
            }
        }
        else
        {
            interaction = "forbidden";
        }
        return $"\nInteraction is {interaction}";
    }
}