using UnityEngine;
using UnityEngine.AI; // B?t bu?c ph?i có ?? dùng NavMeshAgent

// ??m b?o GameObject này luôn có NavMeshAgent
[RequireComponent(typeof(NavMeshAgent))]
public class EnemyAnimationController : MonoBehaviour
{
    private NavMeshAgent agent;
    private Animator animator;

    // Cache (l?u) l?i tên các tham s? ?? t?i ?u hi?u su?t
    private readonly int moveXHash = Animator.StringToHash("moveX");
    private readonly int moveYHash = Animator.StringToHash("moveY");

    void Start()
    {
        // 1. L?y NavMeshAgent t? chính GameObject này ("Enemy1")
        agent = GetComponent<NavMeshAgent>();

        // 2. L?y Animator t? GameObject con ("Model")
        // GetComponentInChildren s? tìm Animator ? "Model"
        animator = GetComponentInChildren<Animator>();

        if (animator == null)
        {
            Debug.LogError("Không tìm th?y Animator ? GameObject con!", this);
        }
    }

    void Update()
    {
        if (agent == null || animator == null) return;

        // 3. L?y v?n t?c (velocity) hi?n t?i c?a NavMeshAgent (?ây là vector 3D)
        Vector3 velocity = agent.velocity;

        // 4. NavMeshAgent di chuy?n trên m?t ph?ng XZ (3D), 
        //    nh?ng Blend Tree 2D c?a b?n dùng X và Y. 
        //    Chúng ta c?n ánh x?:
        //    - velocity.x (trái/ph?i) -> "moveX"
        //    - velocity.z (t?i/lùi) -> "moveY"

        // 5. Chu?n hóa (Normalize) vector v?n t?c ?? ??a v? giá tr? trong kho?ng -1 ??n 1
        //    mà Blend Tree c?a b?n mong mu?n.
        Vector3 normalizedVelocity = new Vector3(velocity.x, velocity.y,1).normalized;

        // 6. C?p nh?t các tham s? trong Animator
        animator.SetFloat(moveXHash, normalizedVelocity.x);
        animator.SetFloat(moveYHash, normalizedVelocity.y);
    }
}