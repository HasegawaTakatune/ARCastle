using UnityEngine;

/// <summary>
/// アニメーションの終了待ち
/// </summary>
public class WaitForAnimation : CustomYieldInstruction
{
    /// <summary>
    /// アニメータ
    /// </summary>
    Animator animator;

    /// <summary>
    /// ハッシュ
    /// </summary>
    int lastStateHash = 0;

    /// <summary>
    /// レイヤ
    /// </summary>
    int layerNo = 0;

    /// <summary>
    /// コンストラクタ
    /// </summary>
    public WaitForAnimation(Animator animator, int layerNo)
    {
        Init(animator, layerNo, animator.GetCurrentAnimatorStateInfo(layerNo).fullPathHash);
    }

    /// <summary>
    /// 初期化
    /// </summary>
    void Init(Animator animator, int layerNo, int hash)
    {
        this.layerNo = layerNo;
        this.animator = animator;
        lastStateHash = hash;
    }

    /// <summary>
    /// 待ち判定の取得
    /// </summary>
    public override bool keepWaiting
    {
        get
        {
            var currentAnimatorState = animator.GetCurrentAnimatorStateInfo(layerNo);
            return currentAnimatorState.fullPathHash == lastStateHash &&
                (currentAnimatorState.normalizedTime < 1);
        }
    }
}
