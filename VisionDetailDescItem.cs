using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using Aki.Config;
using CSharpScript.Game.Phantom.Vision.View;
using CSharpScript.Game.Ui;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.CompilerServices;
using UnrealEngine;

// Token: 0x020019A5 RID: 6565
[NullableContext(1)]
[Nullable(0)]
public class VisionDetailDescItem : UiPanelBase
{
	// Token: 0x0600BC93 RID: 48275 RVA: 0x00321038 File Offset: 0x0031F238
	public VisionDetailDescItem(UUIItem actor)
	{
		this.SourceItem = actor;
	}

	// Token: 0x0600BC94 RID: 48276 RVA: 0x00321048 File Offset: 0x0031F248
	public UniTask Init()
	{
		global::VisionDetailDescItem.<Init>d__5 <Init>d__;
		<Init>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
		<Init>d__.<>4__this = this;
		<Init>d__.<>1__state = -1;
		<Init>d__.<>t__builder.Start<global::VisionDetailDescItem.<Init>d__5>(ref <Init>d__);
		return <Init>d__.<>t__builder.Task;
	}

	// Token: 0x0600BC95 RID: 48277 RVA: 0x0032108C File Offset: 0x0031F28C
	protected unsafe override void OnRegisterComponent()
	{
		int num = 13;
		List<ValueTuple<int, Type>> list = new List<ValueTuple<int, Type>>(num);
		CollectionsMarshal.SetCount<ValueTuple<int, Type>>(list, num);
		Span<ValueTuple<int, Type>> span = CollectionsMarshal.AsSpan<ValueTuple<int, Type>>(list);
		int num2 = 0;
		*span[num2] = new ValueTuple<int, Type>(0, typeof(UUIText));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(1, typeof(UUIItem));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(2, typeof(UUIText));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(3, typeof(UUIText));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(4, typeof(UUIItem));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(5, typeof(UUIItem));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(6, typeof(UUIText));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(7, typeof(UUIItem));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(8, typeof(UUIText));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(9, typeof(UUIItem));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(10, typeof(UUIItem));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(11, typeof(UUIText));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(12, typeof(UUIItem));
		this.ComponentRegisterInfos = list;
	}

	// Token: 0x0600BC96 RID: 48278 RVA: 0x00321268 File Offset: 0x0031F468
	protected override UniTask OnBeforeStartAsync()
	{
		global::VisionDetailDescItem.<OnBeforeStartAsync>d__7 <OnBeforeStartAsync>d__;
		<OnBeforeStartAsync>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
		<OnBeforeStartAsync>d__.<>4__this = this;
		<OnBeforeStartAsync>d__.<>1__state = -1;
		<OnBeforeStartAsync>d__.<>t__builder.Start<global::VisionDetailDescItem.<OnBeforeStartAsync>d__7>(ref <OnBeforeStartAsync>d__);
		return <OnBeforeStartAsync>d__.<>t__builder.Task;
	}

	// Token: 0x0600BC97 RID: 48279 RVA: 0x003212AB File Offset: 0x0031F4AB
	public void Update(VisionDetailDesc data)
	{
		this.Data = data;
		this.RefreshTitle(data);
		this.RefreshContent(data);
		this.RefreshEmpty(data);
		this.RefreshTitleItem(data);
		this.RefreshEmptyText(data);
		this.RefreshEmptyContentItem(data);
		this.RefreshElement(data);
	}

	// Token: 0x0600BC98 RID: 48280 RVA: 0x003212E5 File Offset: 0x0031F4E5
	private void RefreshTitle(VisionDetailDesc data)
	{
		base.GetText(0).SetText(data.Title, true);
	}

	// Token: 0x0600BC99 RID: 48281 RVA: 0x003212FC File Offset: 0x0031F4FC
	private void RefreshContent(VisionDetailDesc data)
	{
		bool ifSimpleState = ModelBase<PhantomBattleModel>.Instance.GetIfSimpleState(1);
		if (data.FetterId > 0)
		{
			PhantomFetter phantomFetterById = ConfigBase<PhantomBattleConfig>.Instance.GetPhantomFetterById(data.FetterId);
			string localTextNew = ConfigMultiTextLang.GetLocalTextNew(phantomFetterById.Name, null);
			base.GetText(2).SetText(localTextNew ?? "", true);
			if (ifSimpleState)
			{
				if (StringUtils.IsEmpty(phantomFetterById.SimplyEffectDesc))
				{
					base.GetText(3).SetText("", true);
				}
				else
				{
					Singleton<LguiUtil>.Instance.SetLocalTextNew(base.GetText(3), phantomFetterById.SimplyEffectDesc, Array.Empty<object>());
				}
			}
			else
			{
				int effectDescriptionParamLength = phantomFetterById.EffectDescriptionParamLength;
				string[] array = new string[effectDescriptionParamLength];
				for (int i = 0; i < effectDescriptionParamLength; i++)
				{
					array[i] = phantomFetterById.EffectDescriptionParam(i);
				}
				Singleton<LguiUtil>.Instance.SetLocalTextNew(base.GetText(3), phantomFetterById.EffectDescription, array);
			}
			base.GetItem(12).SetUIActive(true);
			base.GetText(2).SetUIActive(true);
			base.GetText(3).SetUIActive(true);
			return;
		}
		if (data.SkillConfig != null)
		{
			PhantomSkill value = data.SkillConfig.Value;
			if (ifSimpleState)
			{
				if (StringUtils.IsEmpty(value.SimplyDescription))
				{
					base.GetText(3).SetText("", true);
				}
				else
				{
					Singleton<LguiUtil>.Instance.SetLocalTextNew(base.GetText(3), value.SimplyDescription, Array.Empty<object>());
				}
			}
			else
			{
				string[] phantomSkillDescExBySkillIdAndQuality = ConfigBase<PhantomBattleConfig>.Instance.GetPhantomSkillDescExBySkillIdAndQuality(value.Id, data.Quality);
				Singleton<LguiUtil>.Instance.SetLocalTextNew(base.GetText(3), value.DescriptionEx, phantomSkillDescExBySkillIdAndQuality);
			}
			base.GetItem(12).SetUIActive(false);
			base.GetText(2).SetUIActive(false);
			base.GetText(3).SetUIActive(true);
		}
	}

	// Token: 0x0600BC9A RID: 48282 RVA: 0x003214C8 File Offset: 0x0031F6C8
	private void RefreshElement(VisionDetailDesc data)
	{
		if (data.FetterId > 0)
		{
			base.GetItem(9).SetUIActive(true);
			PhantomFetterGroup fetterGroupById = ConfigBase<PhantomBattleConfig>.Instance.GetFetterGroupById(data.FetterGroupId);
			this.VisionFetterSuitItem.Update(new PhantomFetterGroup?(fetterGroupById));
			base.GetText(11).SetText("", true);
			return;
		}
		base.GetItem(9).SetUIActive(false);
	}

	// Token: 0x0600BC9B RID: 48283 RVA: 0x00321530 File Offset: 0x0031F730
	private void RefreshEmpty(VisionDetailDesc data)
	{
		base.GetItem(4).SetUIActive(data.EmptyState);
	}

	// Token: 0x0600BC9C RID: 48284 RVA: 0x00321544 File Offset: 0x0031F744
	private void RefreshEmptyText(VisionDetailDesc data)
	{
		base.GetText(6).SetText(data.EmptyText, true);
	}

	// Token: 0x0600BC9D RID: 48285 RVA: 0x0032155C File Offset: 0x0031F75C
	private void RefreshEmptyContentItem(VisionDetailDesc data)
	{
		bool uiactive = !StringUtils.IsEmpty(data.EmptyContentText);
		base.GetItem(7).SetUIActive(uiactive);
		base.GetText(8).SetText(data.EmptyContentText, true);
	}

	// Token: 0x0600BC9E RID: 48286 RVA: 0x00321598 File Offset: 0x0031F798
	private void RefreshTitleItem(VisionDetailDesc data)
	{
		base.GetItem(5).SetUIActive(data.TitleItemShowState);
	}

	// Token: 0x04005935 RID: 22837
	[Nullable(2)]
	private readonly UUIItem SourceItem;

	// Token: 0x04005936 RID: 22838
	[Nullable(2)]
	protected VisionDetailDesc Data;

	// Token: 0x04005937 RID: 22839
	[Nullable(2)]
	private VisionFetterSuitItem VisionFetterSuitItem;

	// Token: 0x02007CAC RID: 31916
	[NullableContext(0)]
	private class EVisionDetailDescItem
	{
		// Token: 0x0402A90E RID: 174350
		public const int TitleText = 0;

		// Token: 0x0402A90F RID: 174351
		public const int ContentItem = 1;

		// Token: 0x0402A910 RID: 174352
		public const int ContentTextOne = 2;

		// Token: 0x0402A911 RID: 174353
		public const int ContentTextTwo = 3;

		// Token: 0x0402A912 RID: 174354
		public const int EmptyItem = 4;

		// Token: 0x0402A913 RID: 174355
		public const int TitleParent = 5;

		// Token: 0x0402A914 RID: 174356
		public const int EmptyText = 6;

		// Token: 0x0402A915 RID: 174357
		public const int EmptyContentItem = 7;

		// Token: 0x0402A916 RID: 174358
		public const int EmptyContentText = 8;

		// Token: 0x0402A917 RID: 174359
		public const int ElementItem = 9;

		// Token: 0x0402A918 RID: 174360
		public const int SuitElementItem = 10;

		// Token: 0x0402A919 RID: 174361
		public const int SuitText = 11;

		// Token: 0x0402A91A RID: 174362
		public const int TitleContentParent = 12;
	}
}
