using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnrealEngine;

// Token: 0x0200241C RID: 9244
[NullableContext(1)]
[Nullable(0)]
public class PersonalBirthItem : AutoAttachExhibitionItemAbstract
{
	// Token: 0x06011E13 RID: 73235 RVA: 0x004EAFC6 File Offset: 0x004E91C6
	public PersonalBirthItem(AActor uiActor) : base(uiActor)
	{
	}

	// Token: 0x06011E14 RID: 73236 RVA: 0x004EAFE9 File Offset: 0x004E91E9
	protected override void OnRegisterComponent()
	{
		this.ComponentRegisterInfos = new List<ValueTuple<int, Type>>
		{
			new ValueTuple<int, Type>(0, typeof(UUIText))
		};
	}

	// Token: 0x06011E15 RID: 73237 RVA: 0x004EB00C File Offset: 0x004E920C
	protected override void OnBeforeDestroy()
	{
		this.Num = null;
	}

	// Token: 0x06011E16 RID: 73238 RVA: 0x004EB01A File Offset: 0x004E921A
	public void RefreshItem()
	{
		this.Num = new int?(this.Dates[base.GetShowItemIndex()]);
		base.GetText(0).SetText(this.Num.ToString(), true);
	}

	// Token: 0x06011E17 RID: 73239 RVA: 0x004EB056 File Offset: 0x004E9256
	public override void SetData(object dates)
	{
		this.Dates = (List<int>)dates;
	}

	// Token: 0x06011E18 RID: 73240 RVA: 0x004EB064 File Offset: 0x004E9264
	public override void OnMoveItem(float vector)
	{
		float height = base.GetAttachItem().ExhibitionView.ItemActor.GetHeight();
		float num = Math.Abs(base.GetRootItem().GetAnchorOffsetY()) / (height / 2f);
		double num2 = Singleton<MathUtils>.Instance.Lerp(1.0, 0.5, (double)num);
		this.Scale.X = 1f;
		this.Scale.Y = 1f;
		this.Scale.Z = 1f;
		this.RootItem.SetUIItemScale(this.Scale);
		base.GetText(0).SetAlpha((float)num2);
	}

	// Token: 0x06011E19 RID: 73241 RVA: 0x004EB10E File Offset: 0x004E930E
	public void BindOnSelected(Action<int> onSelected)
	{
		this.OnSelectedCallback = onSelected;
	}

	// Token: 0x06011E1A RID: 73242 RVA: 0x004EB117 File Offset: 0x004E9317
	public override void OnSelect()
	{
		if (this.OnSelectedCallback != null)
		{
			this.OnSelectedCallback(this.Num.Value);
		}
	}

	// Token: 0x04008BE7 RID: 35815
	[Nullable(2)]
	public List<int> Dates;

	// Token: 0x04008BE8 RID: 35816
	private FVector Scale = new FVector(0f, 0f, 0f);

	// Token: 0x04008BE9 RID: 35817
	private int? Num;

	// Token: 0x04008BEA RID: 35818
	[Nullable(2)]
	private Action<int> OnSelectedCallback;
}
