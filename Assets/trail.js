#pragma strict
//multiple touch and trails

var grabbed : Transform;
var grabDistance : float = 10.0f;

var useToggleDrag : boolean; // Didn't know which style you prefer. 
private var objtrl : Hashtable;
var objectins : Transform;
var sparks : Transform;
private var pcount : int;

private var i : int;

public static var maxtouches : int;
public static var pmaxtouches : int;
public static var milktouch: boolean;
public static var lasttime : float;
 
function Start()
{
    objtrl = new Hashtable();
    pcount = 0;
    #if UNITY_IPHONE
        Destroy( transform.gameObject.GetComponent("TrailRenderer") );
    #endif
    sparks.gameObject.SetActive(false);
    maxtouches = 1;
    milktouch = false;
    lasttime = Time.time;
    
    pmaxtouches = maxtouches;
}

function Update () 
{
    UpdateHoldDrag();
    if( !milktouch )
    {
        maxtouches = 1;        
    }
    else
    {
        maxtouches = 5;
    } 
    if( milktouch && Time.time - lasttime >= 3 )
    {
        print("stopped ...");
        maxtouches = 1;
        milktouch = false;
        lasttime = Time.time;
    }
}

function UpdateHoldDrag () 
{
    #if UNITY_IPHONE
    if (Input.touchCount > 0) 
    {
        if ( grabbed && pmaxtouches == maxtouches && (pcount == maxtouches || pcount == Input.touchCount) )
            OldDrag();
        else
        { 
            Grab();
            pmaxtouches = maxtouches;
        }
    }
    else
    {
        objtrl = new Hashtable();
        for( var o : GameObject in GameObject.FindGameObjectsWithTag("trail") )
        {
            Destroy( o );
        }
        pcount = 0;
        grabbed = null;
    } 
    #endif
    
    #if UNITY_EDITOR
    if (Input.GetMouseButton(0)) 
        if (grabbed)
            OldDrag();
        else 
            Grab();
    else
    {
        sparks.gameObject.SetActive(false);
        grabbed = null;
        
    }
    #endif   
    
    #if UNITY_STANDALONE_OSX
    if (Input.GetMouseButton(0)) 
        if (grabbed)
            OldDrag();
        else 
            Grab();
    else
    {
        sparks.gameObject.active = false;
        grabbed = null;
        
    }
    #endif   
}

function Grab() 
{    
    #if UNITY_IPHONE
    if( pcount < maxtouches || pcount < Input.touchCount)
    {
        if( maxtouches <= Input.touchCount )
        {
            for( i=pcount; i< maxtouches; i++)
            {   
                grabbed = Instantiate( objectins, Camera.main.ScreenToWorldPoint(Input.touches[i].position), Quaternion.identity) as Transform;
                if( !objtrl[i+""] ) 
                    objtrl.Add(i+"", grabbed);
               }
               pcount = maxtouches;
           }
           else
           {
               for( i=pcount; i< Input.touchCount; i++)
            {   
                grabbed = Instantiate( objectins, Camera.main.ScreenToWorldPoint(Input.touches[i].position), Quaternion.identity) as Transform;
                if( !objtrl[i+""] ) 
                    objtrl.Add(i+"", grabbed);
               }
               pcount = Input.touchCount;
           }
       }
       else
       {
           objtrl = new Hashtable();
        for( var o : GameObject in GameObject.FindGameObjectsWithTag("trail") )
        {
            Destroy( o );
        }
        if( maxtouches < Input.touchCount )
        {
            for( i=0; i< maxtouches; i++)
            {   
                grabbed = Instantiate( objectins, Camera.main.ScreenToWorldPoint(Input.touches[i].position), Quaternion.identity) as Transform;
                if( !objtrl[i+""] ) 
                    objtrl.Add(i+"", grabbed);
               }
               pcount = maxtouches;
        }
        else
        {
               for( i=0; i< Input.touchCount; i++)
            {   
                grabbed = Instantiate( objectins, Camera.main.ScreenToWorldPoint(Input.touches[i].position), Quaternion.identity) as Transform;
                if( !objtrl[i+""] ) 
                    objtrl.Add(i+"", grabbed);
               }
               pcount = Input.touchCount;
           }
       }
       #endif
       #if UNITY_EDITOR
       grabbed = GameObject.Find("TrailP").transform;
       #endif
       #if UNITY_STANDALONE_OSX
       grabbed = GameObject.Find("TrailP").transform;
       #endif
}

function OldDrag() 
{
        
    var ray : Ray;
    var tt: Transform;
    
    #if UNITY_IPHONE
    for( var i: int; i< objtrl.Count; i++)
    {
        if( Input.touchCount > i )
        {
            ray =  Camera.main.ScreenPointToRay(Input.touches[i].position);
            tt = objtrl[i+""] as Transform;
            tt.transform.position = ray.origin+ ray.direction * grabDistance;            
        }
    }
    #endif
    
    #if UNITY_EDITOR
    sparks.gameObject.SetActive(true);
    ray = Camera.main.ScreenPointToRay(Input.mousePosition);
    grabbed.position = ray.origin+ ray.direction * grabDistance;
    #endif
    
    #if UNITY_STANDALONE_OSX
    sparks.gameObject.active = true;
    ray = Camera.main.ScreenPointToRay(Input.mousePosition);
    grabbed.position = ray.origin+ ray.direction * grabDistance;
    #endif
}