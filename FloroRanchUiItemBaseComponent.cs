using System;
using System.Runtime.CompilerServices;
using Cysharp.Threading.Tasks;

// Token: 0x02001BE9 RID: 7145
[NullableContext(1)]
[Nullable(0)]
public abstract class FloroRanchUiItemBaseComponent : FloroRanchEntityComponentBase
{
	// Token: 0x0600CFD7 RID: 53207
	public abstract FloroRanchUiItemBase GetUiItem();

	// Token: 0x0600CFD8 RID: 53208
	[return: Nullable(new byte[]
	{
		0,
		2
	})]
	public abstract UniTask<FloroRanchUiItemBase> PlayShowAnim();

	// Token: 0x0600CFD9 RID: 53209
	[return: Nullable(new byte[]
	{
		0,
		2
	})]
	public abstract UniTask<FloroRanchUiItemBase> CreateUiItem();

	// Token: 0x0600CFDA RID: 53210
	public abstract UniTask PlayHideAnim();

	// Token: 0x0600CFDB RID: 53211
	public abstract UniTask PlayNormalAnim();

	// Token: 0x0600CFDC RID: 53212 RVA: 0x00373141 File Offset: 0x00371341
	public virtual UniTask ShowUiItem()
	{
		return UniTask.CompletedTask;
	}

	// Token: 0x0600CFDD RID: 53213 RVA: 0x00373148 File Offset: 0x00371348
	public virtual UniTask HideUiItem()
	{
		return UniTask.CompletedTask;
	}

	// Token: 0x0600CFDE RID: 53214 RVA: 0x0037314F File Offset: 0x0037134F
	public virtual void Pause()
	{
	}

	// Token: 0x0600CFDF RID: 53215 RVA: 0x00373151 File Offset: 0x00371351
	public virtual void Resume()
	{
	}

	// Token: 0x0600CFE0 RID: 53216 RVA: 0x00373153 File Offset: 0x00371353
	public virtual void Exit()
	{
	}

	// Token: 0x0600CFE1 RID: 53217 RVA: 0x00373155 File Offset: 0x00371355
	protected virtual void OnExit()
	{
		this.IsExit = true;
	}

	// Token: 0x0600CFE2 RID: 53218 RVA: 0x0037315E File Offset: 0x0037135E
	public bool CheckIsExit()
	{
		return this.IsExit;
	}

	// Token: 0x0600CFE3 RID: 53219 RVA: 0x00373166 File Offset: 0x00371366
	public virtual UniTask MoveToTarget(FloroRanchUiItemBase uiItemBase)
	{
		return UniTask.CompletedTask;
	}

	// Token: 0x0600CFE4 RID: 53220 RVA: 0x0037316D File Offset: 0x0037136D
	public virtual UniTask MoveToOriginalPosition()
	{
		return UniTask.CompletedTask;
	}

	// Token: 0x0600CFE5 RID: 53221 RVA: 0x00373174 File Offset: 0x00371374
	public virtual UniTask PlayEatAnim()
	{
		return UniTask.CompletedTask;
	}

	// Token: 0x0600CFE6 RID: 53222 RVA: 0x0037317B File Offset: 0x0037137B
	public virtual UniTask PlayBeEatAnim()
	{
		return UniTask.CompletedTask;
	}

	// Token: 0x0600CFE7 RID: 53223 RVA: 0x00373182 File Offset: 0x00371382
	public virtual UniTask PlaySacrificeAnim()
	{
		return UniTask.CompletedTask;
	}

	// Token: 0x0600CFE8 RID: 53224 RVA: 0x00373189 File Offset: 0x00371389
	public virtual UniTask PlayFusionHideAnim()
	{
		return UniTask.CompletedTask;
	}

	// Token: 0x0600CFE9 RID: 53225 RVA: 0x00373190 File Offset: 0x00371390
	public virtual UniTask PlayFusionShowAnim()
	{
		return UniTask.CompletedTask;
	}

	// Token: 0x0600CFEA RID: 53226 RVA: 0x00373197 File Offset: 0x00371397
	public virtual UniTask PlayEvolveUpAnim()
	{
		return UniTask.CompletedTask;
	}

	// Token: 0x0600CFEB RID: 53227 RVA: 0x0037319E File Offset: 0x0037139E
	public virtual UniTask PlaySkillAnim()
	{
		return UniTask.CompletedTask;
	}

	// Token: 0x0600CFEC RID: 53228 RVA: 0x003731A5 File Offset: 0x003713A5
	public virtual void PlayVideo()
	{
	}

	// Token: 0x040062F1 RID: 25329
	private bool IsExit;
}
