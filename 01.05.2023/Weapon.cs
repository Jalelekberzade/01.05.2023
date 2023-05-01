namespace _01._05._2023
{
    public class Weapon : MonoBehaviour
    {
        [SerializeField] private Transform bulletPref;
        [SerializeField] private Transform firePosition;

        void Update()
        {
            if (Input.GetMouseButtonDown(0))
            {

                Transform bullet = Instantiate(bulletPref);
                bullet.position = firePosition.position;

                bullet.GetComponent<Rigidbody>().AddForce(firePosition.forward * 50, ForceMode.Impulse);
            }
        }
    }


}
