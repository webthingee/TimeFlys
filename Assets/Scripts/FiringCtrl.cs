using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FiringCtrl : MonoBehaviour 
{
	public GameObject leftGun;
    public GameObject rightGun;
    public GameObject projectile;
    public int weaponID;
	public float rateOfFire = 1f;
    public bool canFire = true;

    void Start()
    {
        StartCoroutine(ChangeID(10f));
    }

    void Update ()
    {
        if (leftGun != null)
        {
            if (Input.GetAxis("Horizontal") < 0 && canFire)
            {
                StartCoroutine(FireBullets(transform.right, leftGun, rateOfFire));
            }
            Colorizer(weaponID, leftGun);
        }

        if (rightGun != null)
        {
            if (Input.GetAxis("Horizontal") > 0 && canFire)
            {
                StartCoroutine(FireBullets(-transform.right, rightGun, rateOfFire));
            }
            Colorizer(weaponID, rightGun);
        }
    }

	IEnumerator FireBullets (Vector3 _direction, GameObject _gun, float _waitTime)
	{			
		canFire = false;
		
		Quaternion _rotation = Quaternion.FromToRotation(Vector3.up, _direction); //same as : bullet.transform.up = direction;
		
		Vector3 _position = _gun.transform.position;
			_position.z = 0;
            _position.x += leftGun ? .75f : -.75f;
		
		GameObject bullet = Instantiate(projectile, _position, _rotation);
			bullet.name = "bullet";
            bullet.GetComponent<Projectile>().projectileID = weaponID;

		yield return new WaitForSeconds(_waitTime);
		
		canFire = true;
	}

    IEnumerator ChangeID (float _waitTime)
    {
        weaponID = Random.Range(1,4);
        yield return new WaitForSeconds(_waitTime);
        StartCoroutine(ChangeID(10f));
    }

    void Colorizer (int _ID, GameObject _gun)
    {
        switch (_ID)
        {
            case 1:
                _gun.GetComponent<SpriteRenderer>().color = Color.red;
                break;
            case 2:
                _gun.GetComponent<SpriteRenderer>().color = Color.white;
                break;
            case 3:
                _gun.GetComponent<SpriteRenderer>().color = Color.blue;
                break;
            default:
                break;
        }
    }
}
