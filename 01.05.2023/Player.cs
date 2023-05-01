namespace _01._05._2023
{
    public class Player : MonoBehaviour
    {
        [SerializeField] private float speed;
        [SerializeField] private float rotationSpeed;
        [SerializeField] private float jumpForce;

        private float _horizontal;
        private float _vertical;
        [SerializeField] private bool _isGround = true;
        private Rigidbody _rigidbody;



        private void Start()
        {
            _rigidbody = GetComponent<Rigidbody>();
        }

        void Update()
        {
            _horizontal = Input.GetAxis("Horizontal");
            _vertical = Input.GetAxis("Vertical");

            if (Input.GetKey(KeyCode.Q))
            {
                transform.rotation *= Quaternion
                    .Euler(new Vector3(0, -1, 0) * rotationSpeed);
            }

            if (Input.GetKey(KeyCode.E))
            {
                transform.rotation *= Quaternion
                    .Euler(new Vector3(0, 1, 0) * rotationSpeed);
            }

            if (Input.GetKey(KeyCode.Space) && _isGround)
            {
                _rigidbody.AddForce(new Vector3(0, 1, 0) * jumpForce);
                _isGround = false;
            }


            transform.position += new Vector3(_horizontal, 0, _vertical) * speed * Time.deltaTime;
        }

        private void OnCollisionEnter(Collision collision)
        {
            if (collision.gameObject.CompareTag("Ground"))
            {
                _isGround = true;
            }
        }
    }

}
