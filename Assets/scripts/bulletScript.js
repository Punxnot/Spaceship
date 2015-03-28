// Public variable 
public var speed : int = 6;

// Gets called once when the bullet is created
function Start () {  
    
}

function Update () {
    transform.Translate(speed * Time.deltaTime,0,0);
 }

// Gets called when the object goes out of the screen
function OnBecameInvisible() {  
    // Destroy the bullet 
    Destroy(gameObject);
}

function OnCollisionEnter2D(coll: Collision2D){
    if (coll.gameObject.tag == "asteroid"){
    	Destroy(gameObject);
    }
}