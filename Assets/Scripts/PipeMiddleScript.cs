using UnityEngine;

public class PipeMiddleScript : MonoBehaviour
{
    public LogicScript logic;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        // Looking for game object with tag "Logic" (our logic manager object), when found it will tke component from game object "LogicScript".
        // Pouziva sa to ako ked pretiahnes napr Rigidbody do scriptu ale v tomto pripade to nejde tak to musime spravit programovo.
        // Tahame iny script do tohto scriptu.
        logic = GameObject.FindGameObjectWithTag("Logic").GetComponent<LogicScript>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.layer == 3)
        {
            logic.addScore(1);
        }

    }

}
