using System;
using System.Runtime.CompilerServices;
using CSharpScript.Game.Module.Util;
using Cysharp.Threading.Tasks;

// Token: 0x02002ADC RID: 10972
[NullableContext(1)]
[Nullable(0)]
public abstract class SurvivorsRogueCardScrollItemBase<[Nullable(2)] TData> : SurvivorsRogueCardBase, IGridProxy<TData>
{
	// Token: 0x17001C6F RID: 7279
	// (get) Token: 0x06015F0C RID: 89868 RVA: 0x0061837B File Offset: 0x0061657B
	// (set) Token: 0x06015F0D RID: 89869 RVA: 0x00618383 File Offset: 0x00616583
	[Nullable(new byte[]
	{
		2,
		1,
		1,
		1
	})]
	public IScrollViewDelegate<IGridProxy<TData>, TData> ScrollViewDelegate { [return: Nullable(new byte[]
	{
		2,
		1,
		1,
		1
	})] get; [param: Nullable(new byte[]
	{
		2,
		1,
		1,
		1
	})] set; }

	// Token: 0x17001C70 RID: 7280
	// (get) Token: 0x06015F0E RID: 89870 RVA: 0x0061838C File Offset: 0x0061658C
	// (set) Token: 0x06015F0F RID: 89871 RVA: 0x00618394 File Offset: 0x00616594
	public int GridIndex { get; set; }

	// Token: 0x17001C71 RID: 7281
	// (get) Token: 0x06015F10 RID: 89872 RVA: 0x0061839D File Offset: 0x0061659D
	// (set) Token: 0x06015F11 RID: 89873 RVA: 0x006183A5 File Offset: 0x006165A5
	public int DisplayIndex { get; set; }

	// Token: 0x06015F12 RID: 89874 RVA: 0x006183AE File Offset: 0x006165AE
	public void Clear()
	{
	}

	// Token: 0x06015F13 RID: 89875
	public abstract UniTask RefreshAsync(TData data, bool isSelected, int gridIndex);

	// Token: 0x06015F14 RID: 89876 RVA: 0x006183B0 File Offset: 0x006165B0
	public virtual void OnSelected(bool fireEvent)
	{
		base.SetSelected(true, fireEvent, false);
	}

	// Token: 0x06015F15 RID: 89877 RVA: 0x006183BB File Offset: 0x006165BB
	public virtual void OnDeselected(bool fireEvent)
	{
		base.SetSelected(false, fireEvent, false);
	}

	// Token: 0x06015F16 RID: 89878 RVA: 0x006183C6 File Offset: 0x006165C6
	public virtual void OnForceSelected(bool bSelected, bool fireEvent)
	{
		base.SetSelected(bSelected, fireEvent, true);
	}

	// Token: 0x06015F17 RID: 89879 RVA: 0x006183D1 File Offset: 0x006165D1
	public virtual object GetKey(TData data, int gridIndex)
	{
		return this.GridIndex;
	}
}
