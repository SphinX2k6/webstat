using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using CSharpScript.Game.Module.AutoAttach;
using CSharpScript.Game.Module.Personal;
using UnrealEngine;

// Token: 0x0200241A RID: 9242
[NullableContext(2)]
[Nullable(0)]
public class PersonalBirthAttachItem : AutoAttachItem<int>
{
	// Token: 0x06011E0A RID: 73226 RVA: 0x004EAE84 File Offset: 0x004E9084
	public PersonalBirthAttachItem(AActor uiItem = null) : base(uiItem)
	{
	}

	// Token: 0x06011E0B RID: 73227 RVA: 0x004EAEB3 File Offset: 0x004E90B3
	protected override void OnRegisterComponent()
	{
		this.ComponentRegisterInfos = new List<ValueTuple<int, Type>>
		{
			new ValueTuple<int, Type>(0, typeof(UUIText))
		};
	}

	// Token: 0x06011E0C RID: 73228 RVA: 0x004EAED6 File Offset: 0x004E90D6
	protected override void OnBeforeDestroy()
	{
		this.Num = null;
	}

	// Token: 0x06011E0D RID: 73229 RVA: 0x004EAEE4 File Offset: 0x004E90E4
	protected override void OnRefreshItem(int data)
	{
		this.Num = new int?(data);
		base.GetText(0).SetText(ConfigBase<PersonalConfig>.Instance.GetBirthLocalText(data, this.DateType), true);
	}

	// Token: 0x06011E0E RID: 73230 RVA: 0x004EAF10 File Offset: 0x004E9110
	protected override void OnMoveItem()
	{
		float currentMovePercentage = base.GetCurrentMovePercentage();
		double num = Singleton<MathUtils>.Instance.Lerp(1.0, 0.5, (double)currentMovePercentage);
		this.Scale.X = 1f;
		this.Scale.Y = 1f;
		this.Scale.Z = 1f;
		this.RootItem.SetUIItemScale(this.Scale);
		base.GetText(0).SetAlpha((float)num);
	}

	// Token: 0x06011E0F RID: 73231 RVA: 0x004EAF92 File Offset: 0x004E9192
	[NullableContext(1)]
	public void BindOnSelected(Action<int> onSelected)
	{
		this.OnSelectedCallback = onSelected;
	}

	// Token: 0x06011E10 RID: 73232 RVA: 0x004EAF9B File Offset: 0x004E919B
	public override void OnSelect()
	{
		if (this.OnSelectedCallback != null)
		{
			this.OnSelectedCallback(this.Num.Value);
		}
	}

	// Token: 0x06011E11 RID: 73233 RVA: 0x004EAFBB File Offset: 0x004E91BB
	protected override void OnUnSelect()
	{
	}

	// Token: 0x06011E12 RID: 73234 RVA: 0x004EAFBD File Offset: 0x004E91BD
	public void SetDateType(EBirthDateType dateType)
	{
		this.DateType = dateType;
	}

	// Token: 0x04008BE1 RID: 35809
	private FVector Scale = new FVector(0f, 0f, 0f);

	// Token: 0x04008BE2 RID: 35810
	private int? Num = new int?(0);

	// Token: 0x04008BE3 RID: 35811
	private Action<int> OnSelectedCallback;

	// Token: 0x04008BE4 RID: 35812
	private EBirthDateType DateType;
}
