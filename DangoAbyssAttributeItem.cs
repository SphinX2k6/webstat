using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Aki.Config;
using CSharpScript.Game.Ui;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.CompilerServices;
using UnrealEngine;

// Token: 0x02001AD1 RID: 6865
[NullableContext(1)]
[Nullable(0)]
public class DangoAbyssAttributeItem : UiPanelBase
{
	// Token: 0x0600C595 RID: 50581 RVA: 0x00343024 File Offset: 0x00341224
	protected override void OnRegisterComponent()
	{
		this.ComponentRegisterInfos = new List<ValueTuple<int, Type>>
		{
			new ValueTuple<int, Type>(0, typeof(UUITexture)),
			new ValueTuple<int, Type>(1, typeof(UUIText)),
			new ValueTuple<int, Type>(2, typeof(UUIText))
		};
	}

	// Token: 0x0600C596 RID: 50582 RVA: 0x0034307E File Offset: 0x0034127E
	public void Initialize(UUIItem uiItem)
	{
		base.CreateByActorAsync(uiItem.GetOwner(), null, false).Forget();
	}

	// Token: 0x0600C597 RID: 50583 RVA: 0x00343093 File Offset: 0x00341293
	protected override void OnStart()
	{
		this.Sequence = new LevelSequencePlayer(this.RootItem);
	}

	// Token: 0x0600C598 RID: 50584 RVA: 0x003430A8 File Offset: 0x003412A8
	public void Refresh(DangoAbyssDefine.EquipViewAttributeData data)
	{
		AttrListScrollData attribute = data.Attribute;
		PropertyIndex value = ConfigBase<PropertyIndexConfig>.Instance.GetPropertyIndexInfo(attribute.Id).Value;
		base.GetText(1).ShowTextNew(value.Name);
		base.SetTextureShowUntilLoaded(value.Icon, base.GetTexture(0), null);
		double propRatioValue = TipsDataTool.GetPropRatioValue(attribute.AddValue, attribute.IsRatio);
		string formatAttributeValueString = ModelBase<AttributeModel>.Instance.GetFormatAttributeValueString(attribute.Id, propRatioValue, attribute.IsRatio);
		base.GetText(2).SetText(formatAttributeValueString, true);
		base.SetUiActive(true);
		if (data.IsChange)
		{
			this.PlaySequence("Change").Forget();
		}
	}

	// Token: 0x0600C599 RID: 50585 RVA: 0x00343158 File Offset: 0x00341358
	public UniTask PlaySequence(string name)
	{
		DangoAbyssAttributeItem.<PlaySequence>d__6 <PlaySequence>d__;
		<PlaySequence>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
		<PlaySequence>d__.<>4__this = this;
		<PlaySequence>d__.name = name;
		<PlaySequence>d__.<>1__state = -1;
		<PlaySequence>d__.<>t__builder.Start<DangoAbyssAttributeItem.<PlaySequence>d__6>(ref <PlaySequence>d__);
		return <PlaySequence>d__.<>t__builder.Task;
	}

	// Token: 0x04005EB2 RID: 24242
	[Nullable(2)]
	public LevelSequencePlayer Sequence;

	// Token: 0x02007DA3 RID: 32163
	[NullableContext(0)]
	private enum EAttributeItemComponent
	{
		// Token: 0x0402ACA7 RID: 175271
		AttributeIcon,
		// Token: 0x0402ACA8 RID: 175272
		AttributeName,
		// Token: 0x0402ACA9 RID: 175273
		AttributeValue
	}
}
