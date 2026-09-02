using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using Aki.Config;
using CSharpScript.Game.Module.Util;
using CSharpScript.Game.Ui;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.CompilerServices;
using UnrealEngine;

// Token: 0x020028EC RID: 10476
[NullableContext(1)]
[Nullable(0)]
public class RoleAttributeItem : UiPanelBase, IGridProxy<RoleAttributeSt>
{
	// Token: 0x17001B4C RID: 6988
	// (get) Token: 0x06014CF1 RID: 85233 RVA: 0x005C38C8 File Offset: 0x005C1AC8
	// (set) Token: 0x06014CF2 RID: 85234 RVA: 0x005C38D0 File Offset: 0x005C1AD0
	[Nullable(new byte[]
	{
		2,
		1,
		1,
		1
	})]
	public IScrollViewDelegate<IGridProxy<RoleAttributeSt>, RoleAttributeSt> ScrollViewDelegate { [return: Nullable(new byte[]
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

	// Token: 0x17001B4D RID: 6989
	// (get) Token: 0x06014CF3 RID: 85235 RVA: 0x005C38D9 File Offset: 0x005C1AD9
	// (set) Token: 0x06014CF4 RID: 85236 RVA: 0x005C38E1 File Offset: 0x005C1AE1
	public int GridIndex { get; set; }

	// Token: 0x17001B4E RID: 6990
	// (get) Token: 0x06014CF5 RID: 85237 RVA: 0x005C38EA File Offset: 0x005C1AEA
	// (set) Token: 0x06014CF6 RID: 85238 RVA: 0x005C38F2 File Offset: 0x005C1AF2
	public int DisplayIndex { get; set; }

	// Token: 0x06014CF7 RID: 85239 RVA: 0x005C38FB File Offset: 0x005C1AFB
	public void CreateThenShowByActor(AActor actor)
	{
	}

	// Token: 0x06014CF8 RID: 85240 RVA: 0x005C3900 File Offset: 0x005C1B00
	public UniTask CreateThenShowByActorAsync(AActor actor)
	{
		RoleAttributeItem.<CreateThenShowByActorAsync>d__14 <CreateThenShowByActorAsync>d__;
		<CreateThenShowByActorAsync>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
		<CreateThenShowByActorAsync>d__.<>1__state = -1;
		<CreateThenShowByActorAsync>d__.<>t__builder.Start<RoleAttributeItem.<CreateThenShowByActorAsync>d__14>(ref <CreateThenShowByActorAsync>d__);
		return <CreateThenShowByActorAsync>d__.<>t__builder.Task;
	}

	// Token: 0x06014CF9 RID: 85241 RVA: 0x005C393C File Offset: 0x005C1B3C
	public UniTask CreateByActorAsync(AActor actor)
	{
		RoleAttributeItem.<CreateByActorAsync>d__15 <CreateByActorAsync>d__;
		<CreateByActorAsync>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
		<CreateByActorAsync>d__.<>1__state = -1;
		<CreateByActorAsync>d__.<>t__builder.Start<RoleAttributeItem.<CreateByActorAsync>d__15>(ref <CreateByActorAsync>d__);
		return <CreateByActorAsync>d__.<>t__builder.Task;
	}

	// Token: 0x06014CFA RID: 85242 RVA: 0x005C3977 File Offset: 0x005C1B77
	public void Refresh(RoleAttributeSt data, bool isSelected, int gridIndex)
	{
		this.Update(data);
	}

	// Token: 0x06014CFB RID: 85243 RVA: 0x005C3980 File Offset: 0x005C1B80
	public void Clear()
	{
	}

	// Token: 0x06014CFC RID: 85244 RVA: 0x005C3982 File Offset: 0x005C1B82
	public void OnSelected(bool fireEvent)
	{
	}

	// Token: 0x06014CFD RID: 85245 RVA: 0x005C3984 File Offset: 0x005C1B84
	public void OnDeselected(bool fireEvent)
	{
	}

	// Token: 0x06014CFE RID: 85246 RVA: 0x005C3986 File Offset: 0x005C1B86
	public object GetKey(RoleAttributeSt data, int gridIndex)
	{
		return this.GridIndex;
	}

	// Token: 0x06014CFF RID: 85247 RVA: 0x005C3994 File Offset: 0x005C1B94
	protected unsafe override void OnRegisterComponent()
	{
		int num = 7;
		List<ValueTuple<int, Type>> list = new List<ValueTuple<int, Type>>(num);
		CollectionsMarshal.SetCount<ValueTuple<int, Type>>(list, num);
		Span<ValueTuple<int, Type>> span = CollectionsMarshal.AsSpan<ValueTuple<int, Type>>(list);
		int num2 = 0;
		*span[num2] = new ValueTuple<int, Type>(0, typeof(UUIText));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(1, typeof(UUIText));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(2, typeof(UUIItem));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(3, typeof(UUIText));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(4, typeof(UUITexture));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(5, typeof(UUISprite));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(6, typeof(UUIItem));
		this.ComponentRegisterInfos = list;
	}

	// Token: 0x06014D00 RID: 85248 RVA: 0x005C3AA2 File Offset: 0x005C1CA2
	protected override void OnStart()
	{
	}

	// Token: 0x06014D01 RID: 85249 RVA: 0x005C3AA4 File Offset: 0x005C1CA4
	public void Update(RoleAttributeSt attrData)
	{
		if (attrData.NeedCheckBg)
		{
			base.GetSprite(5).SetUIActive(this.GridIndex % 2 == 0);
		}
		else
		{
			base.GetSprite(5).SetUIActive(!attrData.Data.NeedHighLight);
		}
		if (attrData.Data.IsUnknown)
		{
			base.GetText(0).SetText("???", true);
			base.GetText(1).SetText("???", true);
			base.GetTexture(4).SetUIActive(false);
			return;
		}
		PropertyIndex value = ConfigBase<PropertyIndexConfig>.Instance.GetPropertyIndexInfo(attrData.Data.Id).Value;
		base.SetTextureByPath(value.Icon, base.GetTexture(4), null, null);
		base.GetText(0).ShowTextNew(value.Name);
		base.GetItem(2).SetUIActive(attrData.Data.AttributeType == CommonComponentDefine.EAttributeType.VisionLevelUp);
		base.GetText(3).SetUIActive(attrData.Data.AttributeType == CommonComponentDefine.EAttributeType.VisionLevelUp);
		this.RefreshAttribute(attrData.Data);
		this.RefreshHighLight(attrData.Data.NeedHighLight);
	}

	// Token: 0x06014D02 RID: 85250 RVA: 0x005C3BCC File Offset: 0x005C1DCC
	private void RefreshAttribute(AttrListScrollData attrData)
	{
		if (attrData.AttributeType == CommonComponentDefine.EAttributeType.VisionSlot || attrData.AttributeType == CommonComponentDefine.EAttributeType.PhantomType || attrData.AttributeType == CommonComponentDefine.EAttributeType.VisionSlotLevelUp)
		{
			base.GetText(1).SetText(ModelBase<AttributeModel>.Instance.GetFormatAttributeValueString(attrData.Id, attrData.BaseValue + attrData.AddValue, attrData.IsRatio), true);
			return;
		}
		base.GetText(3).SetText(ModelBase<AttributeModel>.Instance.GetFormatAttributeValueString(attrData.Id, attrData.AddValue, attrData.IsRatio), true);
		base.GetText(1).SetText(ModelBase<AttributeModel>.Instance.GetFormatAttributeValueString(attrData.Id, attrData.BaseValue, attrData.IsRatio), true);
	}

	// Token: 0x06014D03 RID: 85251 RVA: 0x005C3C77 File Offset: 0x005C1E77
	private void RefreshHighLight(bool bEnable)
	{
		base.GetItem(6).SetUIActive(bEnable);
	}

	// Token: 0x02008C42 RID: 35906
	[NullableContext(0)]
	private enum EChildType
	{
		// Token: 0x0402F3E3 RID: 193507
		AttributeText,
		// Token: 0x0402F3E4 RID: 193508
		AttributeNumText,
		// Token: 0x0402F3E5 RID: 193509
		ArrowItem,
		// Token: 0x0402F3E6 RID: 193510
		AttributeAddText,
		// Token: 0x0402F3E7 RID: 193511
		AttributeIcon,
		// Token: 0x0402F3E8 RID: 193512
		Bg,
		// Token: 0x0402F3E9 RID: 193513
		HighLightItem
	}
}
