using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.UI;
using TMPro;

public class PokemonController : MonoBehaviour
{
    //Variabler for at gøre det nemmere at skrive
    static Pokemon.PokemonType Normal = Pokemon.PokemonType.Normal;
    static Pokemon.PokemonType Fire = Pokemon.PokemonType.Fire;
    static Pokemon.PokemonType Water = Pokemon.PokemonType.Water;
    static Pokemon.PokemonType Grass = Pokemon.PokemonType.Grass;
    static Pokemon.PokemonType Electric = Pokemon.PokemonType.Electric;
    static Pokemon.PokemonType Ice = Pokemon.PokemonType.Ice;
    static Pokemon.PokemonType Fighting = Pokemon.PokemonType.Fighting;
    static Pokemon.PokemonType Poison = Pokemon.PokemonType.Poison;
    static Pokemon.PokemonType Ground = Pokemon.PokemonType.Ground;
    static Pokemon.PokemonType Flying = Pokemon.PokemonType.Flying;
    static Pokemon.PokemonType Psychic = Pokemon.PokemonType.Psychic;
    static Pokemon.PokemonType Bug = Pokemon.PokemonType.Bug;
    static Pokemon.PokemonType Rock = Pokemon.PokemonType.Rock;
    static Pokemon.PokemonType Ghost = Pokemon.PokemonType.Ghost;
    static Pokemon.PokemonType Dragon = Pokemon.PokemonType.Dragon;
    static Pokemon.PokemonType Dark = Pokemon.PokemonType.Dark;
    static Pokemon.PokemonType Steel = Pokemon.PokemonType.Steel;
    static Pokemon.PokemonType Fairy = Pokemon.PokemonType.Fairy;


    //Dictionary for hvilke attacks der gør mindre skade
    static Dictionary<Pokemon.PokemonType, List<Pokemon.PokemonType>> TypeWeaknesses = new Dictionary<Pokemon.PokemonType, List<Pokemon.PokemonType>>()
    {
        {Normal, new List<Pokemon.PokemonType>() { Rock, Steel} },
        {Fire, new List<Pokemon.PokemonType>() { Fire, Water, Rock, Dragon} },
        {Water, new List<Pokemon.PokemonType>() { Water, Grass,Dragon} },
        {Grass, new List<Pokemon.PokemonType>() { Fire, Grass,Poison, Flying, Bug, Dragon, Steel} },
        {Electric, new List<Pokemon.PokemonType>() { Grass, Electric,Dragon} },
        {Ice, new List<Pokemon.PokemonType>() { Fire, Water,Ice, Steel} },
        {Fighting, new List<Pokemon.PokemonType>() { Poison, Flying,Psychic, Bug, Fairy} },
        {Poison, new List<Pokemon.PokemonType>() { Poison, Ground,Bug, Ghost} },
        {Ground, new List<Pokemon.PokemonType>() { Grass, Bug} },
        {Flying, new List<Pokemon.PokemonType>() { Electric, Rock, Steel} },
        {Psychic, new List<Pokemon.PokemonType>() { Psychic, Steel} },
        {Bug, new List<Pokemon.PokemonType>() { Fire, Fighting, Poison, Flying, Ghost, Steel, Fairy} },
        {Rock, new List<Pokemon.PokemonType>() { Fighting, Ground, Steel} },
        {Ghost, new List<Pokemon.PokemonType>() { Dragon} },
        {Dragon, new List<Pokemon.PokemonType>() { Steel} },
        {Dark, new List<Pokemon.PokemonType>() { Fighting, Dark, Fairy} },
        {Steel, new List<Pokemon.PokemonType>() { Fire, Water, Electric, Steel} },
        {Fairy, new List<Pokemon.PokemonType>() { Fire, Poison, Steel} },
    };

    //Dictionary for hvilke attacks der gør bonus skade
    static Dictionary<Pokemon.PokemonType, List<Pokemon.PokemonType>> TypeAmplifier = new Dictionary<Pokemon.PokemonType, List<Pokemon.PokemonType>>()
    {
        {Normal, new List<Pokemon.PokemonType>() { } },
        {Fire, new List<Pokemon.PokemonType>() { Grass, Ice, Bug, Steel} },
        {Water, new List<Pokemon.PokemonType>() { Water, Ground, Rock} },
        {Grass, new List<Pokemon.PokemonType>() { Water, Ground, Rock} },
        {Electric, new List<Pokemon.PokemonType>() { Water, Flying} },
        {Ice, new List<Pokemon.PokemonType>() { Grass, Ground, Flying, Dragon} },
        {Fighting, new List<Pokemon.PokemonType>() { Normal, Ice, Rock, Dark, Steel} },
        {Poison, new List<Pokemon.PokemonType>() { Grass, Fairy} },
        {Ground, new List<Pokemon.PokemonType>() { Fire, Electric, Poison, Rock, Steel} },
        {Flying, new List<Pokemon.PokemonType>() { Grass, Fighting, Bug } },
        {Psychic, new List<Pokemon.PokemonType>() { Fighting, Poison,  } },
        {Bug, new List<Pokemon.PokemonType>() { Grass, Psychic, Dragon} },
        {Rock, new List<Pokemon.PokemonType>() { Fire, Ice, Ground, Bug} },
        {Ghost, new List<Pokemon.PokemonType>() { Psychic, Ghost} },
        {Dragon, new List<Pokemon.PokemonType>() { Dragon} },
        {Dark, new List<Pokemon.PokemonType>() { Psychic, Rock} },
        {Steel, new List<Pokemon.PokemonType>() { Ice, Rock, Fairy} },
        {Fairy, new List<Pokemon.PokemonType>() { Fighting, Dragon, Dark} },
    };

    // Dictionary for hvilke attacks der gør intet skade
    static Dictionary<Pokemon.PokemonType, List<Pokemon.PokemonType>> TypeZero = new Dictionary<Pokemon.PokemonType, List<Pokemon.PokemonType>>()
    {
        {Normal, new List<Pokemon.PokemonType>() { Ghost } },
        {Fire, new List<Pokemon.PokemonType>() { } },
        {Water, new List<Pokemon.PokemonType>() { } },
        {Grass, new List<Pokemon.PokemonType>() { } },
        {Electric, new List<Pokemon.PokemonType>() { Ground} },
        {Ice, new List<Pokemon.PokemonType>() { } },
        {Fighting, new List<Pokemon.PokemonType>() { Ghost} },
        {Poison, new List<Pokemon.PokemonType>() { Steel} },
        {Ground, new List<Pokemon.PokemonType>() { Flying} },
        {Flying, new List<Pokemon.PokemonType>() { } },
        {Psychic, new List<Pokemon.PokemonType>() { Dark} },
        {Bug, new List<Pokemon.PokemonType>() { } },
        {Rock, new List<Pokemon.PokemonType>() { } },
        {Ghost, new List<Pokemon.PokemonType>() { Normal} },
        {Dragon, new List<Pokemon.PokemonType>() { Fairy} },
        {Dark, new List<Pokemon.PokemonType>() { } },
        {Steel, new List<Pokemon.PokemonType>() { } },
        {Fairy, new List<Pokemon.PokemonType>() { } },
    };

    // Base Variabler
    public Pokemon pokemon;
    public Animator animator;
    
    // Ai stuff
    public bool PositionLocked = false;
    public NavMeshAgent agent;
    public Vector3 TargetPosition;

    // Pokemon stats
    public float Health;
    public float MaxHealth;
    public int Level;
    public List<Attack> Attacks;
    public List<Attack> AllAttacks;

    // Renderer stuff
    public MeshFilter meshFilter;
    public MeshRenderer meshRenderer;
    private GameObject MeshObject;

    // Ui stuff
    public GameObject Canvas;
    public TextMeshProUGUI NavneText;
    public TextMeshProUGUI LevelText;
    public RawImage[] TypeImages;

    // Capture stuff
    [HideInInspector]public float CaptureIn;
    [HideInInspector]public bool CountDown;

    public void Initiate()
    {
        if (pokemon == null) Destroy(gameObject);
        MeshObject = meshFilter.gameObject;
        meshFilter.mesh = pokemon.mesh;
        meshRenderer.material = pokemon.Material;

        //Vælg et tilfældigt lvl når pokemonen spawner og giv liv baseret på lvl.
        MaxHealth = 5 + (Level * 0.2f * 20);
        Health = MaxHealth;

        // Tilføj attacks som matcher type
        foreach (Attack attack in AllAttacks)
        {
            if (isType(attack.AttackType))
            {
                Attacks.Add(attack);
            }
        }
    }

    public void Awake()
    {
        Initiate();
    }

    bool isType(Pokemon.PokemonType type)
    {
        if (pokemon.Type.Contains(type))
        {
            return true;
        }
        return false;
    }

    public bool Capture(Transform pokeball)
    {
        if (Random.Range(1, 3) != 123) // Skal laves om til 50/50
        {
            animator.SetTrigger("InCapture");
            return true;
        }
        else
        {
            return false;
        }
    }

    private bool Contains(List<Pokemon.PokemonType> types, Pokemon.PokemonType type)
    {
        return types.Contains(type);
    }

    public float Mitigate(float Damage, Pokemon.PokemonType type)
    {
        float MitigatedDamage = Damage;
        foreach (Pokemon.PokemonType _type in TypeWeaknesses[type])
        {
            if (pokemon.Type.Contains(_type))
                MitigatedDamage /= 2;
        }
        foreach (Pokemon.PokemonType _type in TypeAmplifier[type])
        {
            if (pokemon.Type.Contains(_type))
                MitigatedDamage *= 2;
        } 
        foreach (Pokemon.PokemonType _type in TypeZero[type])
        {
            if (pokemon.Type.Contains(_type))
                MitigatedDamage = 0;
        }
        return MitigatedDamage;
    }

    public void TakeDamage(float Damage, Pokemon.PokemonType DamageType)
    {
        Health -= Mitigate(Damage, DamageType);
        Health = Mathf.Floor(Health);

        if (Health <= 0)
        {
            Destroy(gameObject);
        }
    }

    //Ai Stuff
    public void FindNewPosition(Vector3 newPos)
    {
        if (newPos != transform.position && PositionLocked)
        {
            return;
        }
        TargetPosition = newPos;
    }

    private void Update()
    {
        UpdateUi();

        agent.isStopped = PositionLocked;
        if (transform.position == new Vector3(TargetPosition.x, transform.position.y, TargetPosition.z) || agent.velocity == Vector3.zero)
        {
            FindNewPosition(new Vector3(Random.Range(transform.position.x - 2, transform.position.x + 2), transform.position.y, Random.Range(transform.position.z - 2, transform.position.z + 2)));
        }
        agent.SetDestination(TargetPosition);
        if (CountDown) { 
            CaptureIn -= Time.deltaTime;
            if (CaptureIn < 0)
            {
                gameObject.SetActive(false);
            }
        }
    }

    public void LevelUp()
    {
        Level++;
        MaxHealth = 5 + (Level * 0.2f * 20);
        Health = MaxHealth;
        if (!pokemon.DoesEvovle) return;
        if (Level >= pokemon.EvolveLevel) Evolve();
    }

    public void Evolve()
    {
        Debug.Log("Evolving");
        pokemon = pokemon.EvolveTo;
        meshFilter.mesh = pokemon.mesh;
        meshRenderer.material = pokemon.Material;
    }

    public void Hit(Attack attack,PokemonController pokemon)
    {
        // Gør skade afhængigt af pokemons level
        // Gør 10% ekstra skade pr level, dvs på level 10 gør så 100% ekstra skade osv.
        pokemon.TakeDamage(attack.Damage + (attack.Damage * (Level * 0.1f)), attack.AttackType);
    }

    void UpdateUi()
    {
        // Fiks canvas
        Canvas.transform.LookAt(Player.player.Camera);
        Canvas.transform.rotation = Canvas.transform.rotation * Quaternion.Euler(1, 180, 1);

        // Opdater text
        NavneText.text = pokemon.name;
        LevelText.text = "lvl " + Level;

        // Opdater billeder
        for (int i = 0; i < TypeImages.Length; i++) // Reset
        {
            TypeImages[i].texture = null;
            TypeImages[i].gameObject.SetActive(true);
        }
        for (int i = 0; i < pokemon.Type.Count; i++) // Sæt billede
        {
            TypeImages[i].texture = pokemon.TypeImages[i];
        }
        for (int i = 0; i < TypeImages.Length; i++) // Fjern billede hvis tom
        {
            if (TypeImages[i].texture == null)
            {
                TypeImages[i].gameObject.SetActive(false);
            }
        }
    }
}
