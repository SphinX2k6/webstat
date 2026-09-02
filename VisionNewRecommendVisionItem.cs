using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Aki.Config;
using CSharpScript.Game.Ui;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.CompilerServices;
using UnrealEngine;

// Token: 0x0200253E RID: 9534
public class VisionNewRecommendVisionItem : UiPanelBase
{
	// Token: 0x060128D4 RID: 75988 RVA: 0x0051C8E0 File Offset: 0x0051AAE0
	protected override void OnRegisterComponent()
	{
		this.ComponentRegisterInfos = new List<ValueTuple<int, Type>>
		{
			new ValueTuple<int, Type>(0, typeof(UUIExtendToggle)),
			new ValueTuple<int, Type>(1, typeof(UUIDraggableComponent)),
			new ValueTuple<int, Type>(2, typeof(UUITexture)),
			new ValueTuple<int, Type>(3, typeof(UUISprite)),
			new ValueTuple<int, Type>(4, typeof(UUIItem)),
			new ValueTuple<int, Type>(5, typeof(UUIText)),
			new ValueTuple<int, Type>(6, typeof(UUIItem)),
			new ValueTuple<int, Type>(7, typeof(UUIItem)),
			new ValueTuple<int, Type>(8, typeof(UUIItem)),
			new ValueTuple<int, Type>(9, typeof(UUIItem)),
			new ValueTuple<int, Type>(10, typeof(UUIItem)),
			new ValueTuple<int, Type>(11, typeof(UUIItem)),
			new ValueTuple<int, Type>(12, typeof(UUIItem)),
			new ValueTuple<int, Type>(13, typeof(UUIItem)),
			new ValueTuple<int, Type>(14, typeof(UUIItem)),
			new ValueTuple<int, Type>(15, typeof(UUIText)),
			new ValueTuple<int, Type>(16, typeof(UUIItem)),
			new ValueTuple<int, Type>(17, typeof(UUIItem))
		};
		this.BtnBindInfo = new List<ValueTuple<int, Delegate>>
		{
			new ValueTuple<int, Delegate>(0, new Action<EToggleState>(this.OnToggleClick))
		};
	}

	// Token: 0x060128D5 RID: 75989 RVA: 0x0051CAB0 File Offset: 0x0051ACB0
	protected override UniTask OnBeforeStartAsync()
	{
		VisionNewRecommendVisionItem.<OnBeforeStartAsync>d__4 <OnBeforeStartAsync>d__;
		<OnBeforeStartAsync>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
		<OnBeforeStartAsync>d__.<>4__this = this;
		<OnBeforeStartAsync>d__.<>1__state = -1;
		<OnBeforeStartAsync>d__.<>t__builder.Start<VisionNewRecommendVisionItem.<OnBeforeStartAsync>d__4>(ref <OnBeforeStartAsync>d__);
		return <OnBeforeStartAsync>d__.<>t__builder.Task;
	}

	// Token: 0x060128D6 RID: 75990 RVA: 0x0051CAF4 File Offset: 0x0051ACF4
	[NullableContext(1)]
	public void SetData(VisionNewRecommendVisionItemData data)
	{
		base.TrySetTextureByPath(ConfigBase<PhantomBattleConfig>.Instance.GetPhantomItemByMonsterId(data.VisionMonsterId)[0].IconMiddle, base.GetTexture(2), null, null);
		base.GetText(5).SetText(data.Cost.ToString(), true);
		PhantomFetterGroup fetterGroupById = ConfigBase<PhantomBattleConfig>.Instance.GetFetterGroupById(data.FetterGroupId);
		this.VisionFetterSuitItem.Update(new PhantomFetterGroup?(fetterGroupById));
	}

	// Token: 0x060128D7 RID: 75991 RVA: 0x0051CB70 File Offset: 0x0051AD70
	public void SetToggleState(EToggleState state, bool fireEvent)
	{
		base.GetExtendToggle(0).SetToggleStateForce(state, fireEvent, false, false);
	}

	// Token: 0x060128D8 RID: 75992 RVA: 0x0051CB82 File Offset: 0x0051AD82
	private void OnToggleClick(EToggleState _)
	{
		Action onSelectedCallback = this.OnSelectedCallback;
		if (onSelectedCallback == null)
		{
			return;
		}
		onSelectedCallback();
	}

	// Token: 0x04009093 RID: 37011
	[Nullable(2)]
	public Action OnSelectedCallback;

	// Token: 0x04009094 RID: 37012
	[Nullable(2)]
	private VisionFetterSuitItem VisionFetterSuitItem;

	// Token: 0x02008867 RID: 34919
	private enum EComponent
	{
		// Token: 0x0402E12A RID: 188714
		ToggleItem,
		// Token: 0x0402E12B RID: 188715
		CircleItem,
		// Token: 0x0402E12C RID: 188716
		CircleItemTexture,
		// Token: 0x0402E12D RID: 188717
		QualitySprite,
		// Token: 0x0402E12E RID: 188718
		CostItem,
		// Token: 0x0402E12F RID: 188719
		CostNumText,
		// Token: 0x0402E130 RID: 188720
		PlusItem,
		// Token: 0x0402E131 RID: 188721
		SuitElementItem,
		// Token: 0x0402E132 RID: 188722
		RedItem,
		// Token: 0x0402E133 RID: 188723
		CircleTextureBlackBg,
		// Token: 0x0402E134 RID: 188724
		AddIconItem,
		// Token: 0x0402E135 RID: 188725
		AniLight,
		// Token: 0x0402E136 RID: 188726
		RemoveItem,
		// Token: 0x0402E137 RID: 188727
		AddIconItem2,
		// Token: 0x0402E138 RID: 188728
		LevelItem,
		// Token: 0x0402E139 RID: 188729
		LevelText,
		// Token: 0x0402E13A RID: 188730
		ItemOccupyPanel,
		// Token: 0x0402E13B RID: 188731
		ItemWarningIcon
	}
}
