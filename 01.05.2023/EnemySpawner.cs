namespace _01._05._2023
{
    public class EnemySpawner : MonoBehaviour
    {
        [SerializeField] private Transform enemyPref;

        void Start()
        {
            StartCoroutine(Spawner());
        }

        IEnumerator Spawner()
        {
            while (true)
            {
                Transform enemy = Instantiate(enemyPref);
                enemy.position = new Vector3(Random.Range(0, 30), 0, Random.Range(0, 30));
                yield return new WaitForSeconds(5f);
            }
        }
    }




}
