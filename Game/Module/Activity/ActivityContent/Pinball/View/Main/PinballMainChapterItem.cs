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

namespace CSharpScript.Game.Module.Activity.ActivityContent.Pinball.View.Main
{
	// Token: 0x020065F6 RID: 26102
	[NullableContext(1)]
	[Nullable(0)]
	public class PinballMainChapterItem : UiPanelBase, IPinballChapterItem
	{
		// Token: 0x06041354 RID: 267092 RVA: 0x010BA138 File Offset: 0x010B8338
		protected unsafe override void OnRegisterComponent()
		{
			int num = 9;
			List<ValueTuple<int, Type>> list = new List<ValueTuple<int, Type>>(num);
			CollectionsMarshal.SetCount<ValueTuple<int, Type>>(list, num);
			Span<ValueTuple<int, Type>> span = CollectionsMarshal.AsSpan<ValueTuple<int, Type>>(list);
			int num2 = 0;
			*span[num2] = new ValueTuple<int, Type>(2, typeof(UUITexture));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(3, typeof(UUITexture));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(4, typeof(UUITexture));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(5, typeof(UUIItem));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(6, typeof(UUIText));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(7, typeof(UUIHorizontalLayout));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(8, typeof(UUIItem));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(0, typeof(UUIButtonComponent));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(9, typeof(UUIItem));
			this.ComponentRegisterInfos = list;
			num2 = 1;
			List<ValueTuple<int, Delegate>> list2 = new List<ValueTuple<int, Delegate>>(num2);
			CollectionsMarshal.SetCount<ValueTuple<int, Delegate>>(list2, num2);
			Span<ValueTuple<int, Delegate>> span2 = CollectionsMarshal.AsSpan<ValueTuple<int, Delegate>>(list2);
			num = 0;
			*span2[num] = new ValueTuple<int, Delegate>(0, new Action(this.OnBtnChapterClick));
			this.BtnBindInfo = list2;
		}

		// Token: 0x06041355 RID: 267093 RVA: 0x010BA2C8 File Offset: 0x010B84C8
		protected override void OnStart()
		{
			this.ProgressLayout = new GenericLayout<PinballMainChapterProgressItem, PinballLevelRecordData>(base.GetHorizontalLayout(7), new Func<PinballMainChapterProgressItem>(this.InitProgressItem), base.GetItem(8).GetOwner() as AUIBaseActor, false, true);
			this.SeqPlayer = new LevelSequencePlayer(this.RootItem);
			UUIEffectOutline extraEffectOutline = base.GetText(6).GetOwner().GetComponentByClass(UUIEffectOutline.StaticClass()) as UUIEffectOutline;
			this.ExtraEffectOutline = extraEffectOutline;
			base.GetButton(0).OnPointEnterCallBack.Bind(new Action(this.OnPointerEnter));
		}

		// Token: 0x06041356 RID: 267094 RVA: 0x010BA35C File Offset: 0x010B855C
		protected override void OnBeforeDestroy()
		{
			base.GetButton(0).OnPointEnterCallBack.Unbind();
		}

		// Token: 0x06041357 RID: 267095 RVA: 0x010BA370 File Offset: 0x010B8570
		[NullableContext(2)]
		public UUIItem GetChapterButtonUiItem()
		{
			UUIButtonComponent button = base.GetButton(0);
			if (button == null)
			{
				return null;
			}
			AUIBaseActor auibaseActor = button.GetOwner() as AUIBaseActor;
			if (auibaseActor == null)
			{
				return null;
			}
			return auibaseActor.GetUIItem();
		}

		// Token: 0x06041358 RID: 267096 RVA: 0x010BA3A0 File Offset: 0x010B85A0
		private EPinballChapterLevelLockStatus GetChapterLockStatus(int chapterId)
		{
			return ModelBase<PinballModel>.Instance.ActivityData.GetChapterLockStatus(chapterId);
		}

		// Token: 0x06041359 RID: 267097 RVA: 0x010BA3B2 File Offset: 0x010B85B2
		void IPinballChapterItem.Refresh(PinballChapterData data)
		{
			this.Refresh(data, false);
		}

		// Token: 0x0604135A RID: 267098 RVA: 0x010BA3BC File Offset: 0x010B85BC
		public void Refresh(PinballChapterData data, bool defaultGray = false)
		{
			PinballChapterConfig? pinballChapterConfigById = ConfigBase<PinballConfig>.Instance.GetPinballChapterConfigById(data.ChapterId);
			EPinballChapterLevelLockStatus chapterLockStatus = this.GetChapterLockStatus(data.ChapterId);
			bool flag = chapterLockStatus == EPinballChapterLevelLockStatus.Lock;
			bool flag2 = chapterLockStatus == EPinballChapterLevelLockStatus.Activated;
			UUITexture texture = base.GetTexture(2);
			UUITexture texture2 = base.GetTexture(3);
			UUITexture texture3 = base.GetTexture(4);
			if (texture != null)
			{
				texture.SetIsGray(defaultGray || !flag2);
			}
			if (texture2 != null)
			{
				texture2.SetIsGray(defaultGray || !flag2);
			}
			if (texture3 != null)
			{
				texture3.SetIsGray(defaultGray || !flag2);
			}
			base.SetTextureByPath(pinballChapterConfigById.Value.IconBg, texture, null, null);
			base.SetTextureByPath(pinballChapterConfigById.Value.IconDecoration, texture2, null, null);
			base.SetTextureByPath(pinballChapterConfigById.Value.IconArtName, texture3, null, null);
			base.GetItem(5).SetUIActive(defaultGray || !flag2);
			List<PinballLevelRecordData> list = new List<PinballLevelRecordData>();
			PinballActivityData activityData = ModelBase<PinballModel>.Instance.ActivityData;
			for (int i = 0; i < pinballChapterConfigById.Value.LevelListLength; i++)
			{
				int levelId = pinballChapterConfigById.Value.LevelList(i);
				PinballLevelRecordData levelData = activityData.GetLevelData(levelId);
				list.Add(levelData);
			}
			this.SetRedDotVisible(activityData.HasNewChapterRedDot(data.ChapterId));
			GenericLayout<PinballMainChapterProgressItem, PinballLevelRecordData> progressLayout = this.ProgressLayout;
			if (progressLayout != null)
			{
				progressLayout.RefreshByData(list, null, false);
			}
			string newText;
			if (flag)
			{
				newText = "???";
				GenericLayout<PinballMainChapterProgressItem, PinballLevelRecordData> progressLayout2 = this.ProgressLayout;
				if (progressLayout2 != null)
				{
					progressLayout2.SetActive(false);
				}
			}
			else
			{
				newText = ConfigMultiTextLang.GetLocalTextNew(pinballChapterConfigById.Value.Name, null);
				GenericLayout<PinballMainChapterProgressItem, PinballLevelRecordData> progressLayout3 = this.ProgressLayout;
				if (progressLayout3 != null)
				{
					progressLayout3.SetActive(true);
				}
			}
			UUIText text = base.GetText(6);
			text.SetText(newText, true);
			text.outlineColor = FColor.FromHex(pinballChapterConfigById.Value.OutlineColor);
			UUIEffectOutline extraEffectOutline = this.ExtraEffectOutline;
			if (extraEffectOutline != null)
			{
				extraEffectOutline.SetOutlineColor(FColor.FromHex(pinballChapterConfigById.Value.ExOutlineColor));
			}
			this.ChapterData = data;
			this.LevelDataList = list;
		}

		// Token: 0x0604135B RID: 267099 RVA: 0x010BA5F4 File Offset: 0x010B87F4
		public void SetProgressActive(bool isActive)
		{
			GenericLayout<PinballMainChapterProgressItem, PinballLevelRecordData> progressLayout = this.ProgressLayout;
			if (progressLayout == null)
			{
				return;
			}
			progressLayout.SetActive(isActive);
		}

		// Token: 0x0604135C RID: 267100 RVA: 0x010BA607 File Offset: 0x010B8807
		public void SetRedDotVisible(bool isVisible)
		{
			UUIItem item = base.GetItem(9);
			if (item == null)
			{
				return;
			}
			item.SetUIActive(isVisible);
		}

		// Token: 0x0604135D RID: 267101 RVA: 0x010BA61C File Offset: 0x010B881C
		public void SetGray(bool isSetGray)
		{
			UUITexture texture = base.GetTexture(2);
			UUITexture texture2 = base.GetTexture(3);
			UUITexture texture3 = base.GetTexture(4);
			if (texture != null)
			{
				texture.SetIsGray(isSetGray);
			}
			if (texture2 != null)
			{
				texture2.SetIsGray(isSetGray);
			}
			if (texture3 != null)
			{
				texture3.SetIsGray(isSetGray);
			}
			base.GetItem(5).SetUIActive(isSetGray);
		}

		// Token: 0x0604135E RID: 267102 RVA: 0x010BA670 File Offset: 0x010B8870
		public UniTask PlayUnlockTweenAsync()
		{
			PinballMainChapterItem.<PlayUnlockTweenAsync>d__18 <PlayUnlockTweenAsync>d__;
			<PlayUnlockTweenAsync>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<PlayUnlockTweenAsync>d__.<>4__this = this;
			<PlayUnlockTweenAsync>d__.<>1__state = -1;
			<PlayUnlockTweenAsync>d__.<>t__builder.Start<PinballMainChapterItem.<PlayUnlockTweenAsync>d__18>(ref <PlayUnlockTweenAsync>d__);
			return <PlayUnlockTweenAsync>d__.<>t__builder.Task;
		}

		// Token: 0x0604135F RID: 267103 RVA: 0x010BA6B3 File Offset: 0x010B88B3
		private PinballMainChapterProgressItem InitProgressItem()
		{
			return new PinballMainChapterProgressItem();
		}

		// Token: 0x06041360 RID: 267104 RVA: 0x010BA6BC File Offset: 0x010B88BC
		private void OnBtnChapterClick()
		{
			if (this.ChapterData == null || this.LevelDataList.Count == 0)
			{
				return;
			}
			EPinballChapterLevelLockStatus chapterLockStatus = this.GetChapterLockStatus(this.ChapterData.ChapterId);
			if (chapterLockStatus == EPinballChapterLevelLockStatus.Lock)
			{
				string localTextNew = ConfigMultiTextLang.GetLocalTextNew("Pinball_Main_ChapterTips01", null);
				string remainTimeText = ModelBase<ActivityModel>.Instance.GetRemainTimeText((long)this.ChapterData.UnlockTime, localTextNew);
				ControllerBase<ScrollingTipsController>.Instance.ShowTipsByText(remainTimeText);
				return;
			}
			if (chapterLockStatus == EPinballChapterLevelLockStatus.PreLock)
			{
				string localTextNew2 = ConfigMultiTextLang.GetLocalTextNew(ConfigBase<PinballConfig>.Instance.GetPinballChapterConfigById(this.ChapterData.PreChapterId).Value.Name, null);
				ControllerBase<ScrollingTipsController>.Instance.ShowTipsByTextId("Pinball_Level_UnlockInfo", new object[]
				{
					localTextNew2
				});
				return;
			}
			this.SetRedDotVisible(false);
			Action<PinballChapterData, List<PinballLevelRecordData>> onClickChapterBack = this.OnClickChapterBack;
			if (onClickChapterBack == null)
			{
				return;
			}
			onClickChapterBack(this.ChapterData, this.LevelDataList);
		}

		// Token: 0x06041361 RID: 267105 RVA: 0x010BA794 File Offset: 0x010B8994
		private void OnPointerEnter()
		{
			if (this.ChapterData == null)
			{
				return;
			}
			int chapterId = this.ChapterData.ChapterId;
			PinballChapterConfig? pinballChapterConfigById = ConfigBase<PinballConfig>.Instance.GetPinballChapterConfigById(chapterId);
			if (pinballChapterConfigById == null || StringUtils.IsBlank(pinballChapterConfigById.Value.PlanetBg) || StringUtils.IsBlank(pinballChapterConfigById.Value.PlanetMaskBg))
			{
				return;
			}
			Action<string, string, int> onPointerEnterChapterBack = this.OnPointerEnterChapterBack;
			if (onPointerEnterChapterBack == null)
			{
				return;
			}
			onPointerEnterChapterBack(pinballChapterConfigById.Value.PlanetBg, pinballChapterConfigById.Value.PlanetMaskBg, chapterId);
		}

		// Token: 0x0402481D RID: 149533
		[Nullable(new byte[]
		{
			2,
			1,
			1,
			1
		})]
		public Action<PinballChapterData, List<PinballLevelRecordData>> OnClickChapterBack;

		// Token: 0x0402481E RID: 149534
		[Nullable(new byte[]
		{
			2,
			1,
			1
		})]
		public Action<string, string, int> OnPointerEnterChapterBack;

		// Token: 0x0402481F RID: 149535
		[Nullable(2)]
		private PinballChapterData ChapterData;

		// Token: 0x04024820 RID: 149536
		private List<PinballLevelRecordData> LevelDataList = new List<PinballLevelRecordData>();

		// Token: 0x04024821 RID: 149537
		[Nullable(2)]
		private LevelSequencePlayer SeqPlayer;

		// Token: 0x04024822 RID: 149538
		[Nullable(2)]
		private UUIEffectOutline ExtraEffectOutline;

		// Token: 0x04024823 RID: 149539
		[Nullable(new byte[]
		{
			2,
			1,
			1
		})]
		private GenericLayout<PinballMainChapterProgressItem, PinballLevelRecordData> ProgressLayout;

		// Token: 0x0200C5FB RID: 50683
		[NullableContext(0)]
		private enum EComponent
		{
			// Token: 0x0403CF15 RID: 249621
			BtnChapter,
			// Token: 0x0403CF16 RID: 249622
			BgIcon,
			// Token: 0x0403CF17 RID: 249623
			TexBg,
			// Token: 0x0403CF18 RID: 249624
			TexDecoration,
			// Token: 0x0403CF19 RID: 249625
			TexArtName,
			// Token: 0x0403CF1A RID: 249626
			LockItem,
			// Token: 0x0403CF1B RID: 249627
			TxtName,
			// Token: 0x0403CF1C RID: 249628
			ProgressLayout,
			// Token: 0x0403CF1D RID: 249629
			ProgressItem,
			// Token: 0x0403CF1E RID: 249630
			RedDotItem
		}
	}
}
