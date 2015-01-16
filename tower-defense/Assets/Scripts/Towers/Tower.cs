using UnityEngine;
using System.Collections;

    // Boy

public class Tower : MonoBehaviour {

    public Bullet bulletPrefab  = null;
    public bool _beingSold      = false;
    public int lvl              = 1;
    public int buildPrice       = 100;
    public int upgradePrice     = 200;
    public float destroyTime    = 3.0f;
    protected float damage      = 0.0f;
    protected float interval    = 2.0f;
    protected float range       = 10.0f;
    protected float timeLeft    = 6.0f;
    protected float fireDelay   = 1.0f;
    private Animator _anim;
    //private AnimatorStateInfo _animInfo;

    private AudioSource MainSource;

    public AudioClip BuildAudio;
    public AudioClip FireAudio;

    Enemy findClosestTarget() {
        Enemy closest = null;
        Vector3 pos = transform.position;

        Enemy[] enemies = (Enemy[])FindObjectsOfType(typeof(Enemy));
        // If array isn't empty
        if (enemies != null) {
            if (enemies.Length > 0) {
                closest = enemies[0];
                for (int i = 1; i < enemies.Length; ++i) {
                    if (enemies[i].dead) continue;
                    float current = Vector3.Distance(pos, enemies[i].transform.position);
                    float old = Vector3.Distance(pos, closest.transform.position);
                    // If the newly detected target is closer than the old (closest) target, set it to closest.
                    if (current < old) {
                        closest = enemies[i];
                    }
                }
            }
        }

        return closest;
    }

    void Awake() {
        MainSource = GetComponent<AudioSource>();
        _anim = GetComponentInChildren<Animator>();
        //_animInfo = _anim.GetCurrentAnimatorStateInfo(0);
        upgradePrice = buildPrice * 2;
        MainSource.PlayOneShot(BuildAudio, 1f);
    }

    void Update() {
        if (!_beingSold) {
            timeLeft -= Time.deltaTime;
            if (timeLeft <= 0.0f) {
                StartCoroutine(FindTarget());
            }
        }
    }

    IEnumerator FindTarget() {
        // Get closest target
        Enemy target = findClosestTarget();
        if (target != null) {
            // Check if in range
            if (Vector3.Distance(transform.position, target.transform.position) <= range) {
                // Charging...
                if (_anim) _anim.Play("animFire");
                timeLeft = interval + fireDelay;
                yield return new WaitForSeconds(fireDelay);
                // Ready to fire
                MainSource.PlayOneShot(FireAudio, 1f);
                Fire(target);
            } else {
                if (_anim) _anim.Play("animIdle");
            }
        } else {
            if (_anim) _anim.Play("animIdle");
        }
    }

    public virtual void Fire(Enemy target) {

    }

    public void SellTower() {
        // Disable the ability to fire
        _beingSold = true;
        // Play the sell anim
        _anim.Play("animSell");
        // Get rid of the tower
        DestroyObject(gameObject, destroyTime);


        // Garbage code:
        #region All this to check the length of the animation, DOESN'T WORK IN RUNTIME!
        /*
        float length = 0;
        int animSpeed = 2;
        string track = "animSell";

        UnityEditorInternal.AnimatorController ac = _anim.runtimeAnimatorController as UnityEditorInternal.AnimatorController;
        UnityEditorInternal.StateMachine sm = ac.GetLayer(0).stateMachine;

        // Loop through all the states
        for (int i = 0; i < sm.stateCount; i++) {
            // Get the state we're on and check if it matches the given track tag
            UnityEditorInternal.State state = sm.GetState(i);
            if (state.tag == track) {
                Debug.Log("State matches given tag");

                AnimationClip clip = state.GetMotion() as AnimationClip;
                if (clip != null) {
                    length = clip.length / animSpeed;
                    Debug.Log("Length = " + length);
                } else {
                    Debug.Log("Clip is Null");
                }

            } else {
                Debug.Log("State doesn't match given tag");
            }
        }
        */
        /*
        if (_anim.GetCurrentAnimatorStateInfo(0).normalizedTime >= 0.99f) {// && !_anim.IsInTransition(0)) {
            Debug.Log("Anim is done");
        } else {
            Debug.Log("nope");
        }
        Debug.Log(_anim.GetCurrentAnimatorStateInfo(0));

        if (_anim.GetCurrentAnimatorStateInfo(0).IsName("animSell")) {
            Debug.Log("Anim is animSell");
        } else {
            Debug.Log("nope");
        }

        if (_animInfo.IsTag("animSell")) {
            Debug.Log("Anim is animSell");
        } else {
            Debug.Log("nope");
        }
        */
        
        
        /*
        float length = 0;
        string track = "animSell";

        if (_anim != null) {
            UnityEditorInternal.AnimatorController ac = _anim.runtimeAnimatorController as UnityEditorInternal.AnimatorController;
            UnityEditorInternal.StateMachine sm = ac.GetLayer(0).stateMachine;

            for (int i = 0; i < sm.stateCount; i++) {
                UnityEditorInternal.State state = sm.GetState(i);
                if (state.uniqueName == track) {
                    AnimationClip clip = state.GetMotion() as AnimationClip;
                    if (clip != null) {
                        length = clip.length;
                        Debug.Log("Clip ain't null, length = " + clip.length);
                    } else {
                        Debug.Log(clip);
                    }
                }
            }
            Debug.Log("Animation:" + track + ":" + length);
        } */
	#endregion

    }

}
