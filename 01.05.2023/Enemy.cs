namespace _01._05._2023
{
    public class Enemy : MonoBehaviour
    {
        [SerializeField] private float speed;
        [SerializeField] private Transform bulletPref;
        [SerializeField] private Transform firePosition;
        [SerializeField] private float attackDelay;


        private Player _player;
        private Vector3 _direction;
        private float _lastAttackTime;

        void Start()
        {
            _player = FindObjectOfType<Player>();
        }

        void Update()
        {

            _direction = _player.transform.position - transform.position;
            _direction.Normalize();
            transform.Translate(_direction * speed * Time.deltaTime);


            transform.LookAt(_player.transform);

            if (Vector3.Distance(_player.transform.position, transform.position) < 5)
            {

                if (Time.time >= _lastAttackTime + attackDelay)
                {
                    Transform bullet = Instantiate(bulletPref);
                    bullet.position = firePosition.position;

                    bullet.GetComponent<Rigidbody>().AddForce(firePosition.forward * 50, ForceMode.Impulse);

                    _lastAttackTime = Time.time;
                }

            }
        }
    }


}
