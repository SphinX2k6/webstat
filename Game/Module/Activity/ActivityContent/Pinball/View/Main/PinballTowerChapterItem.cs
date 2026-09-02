using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using Aki.Config;
using CSharpScript.Game.Ui;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.CompilerServices;
using UnrealEngine;

namespace CSharpScript.Game.Module.Activity.ActivityContent.Pinball.View.Main
{
	// Token: 0x020065FF RID: 26111
	[NullableContext(2)]
	[Nullable(0)]
	public class PinballTowerChapterItem : UiPanelBase, IPinballChapterItem
	{
		// Token: 0x060413F1 RID: 267249 RVA: 0x010BCA80 File Offset: 0x010BAC80
		protected unsafe override void OnRegisterComponent()
		{
			int num = 8;
			List<ValueTuple<int, Type>> list = new List<ValueTuple<int, Type>>(num);
			CollectionsMarshal.SetCount<ValueTuple<int, Type>>(list, num);
			Span<ValueTuple<int, Type>> span = CollectionsMarshal.AsSpan<ValueTuple<int, Type>>(list);
			int num2 = 0;
			*span[num2] = new ValueTuple<int, Type>(0, typeof(UUIButtonComponent));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(1, typeof(UUIItem));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(2, typeof(UUITexture));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(3, typeof(UUITexture));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(4, typeof(UUIItem));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(5, typeof(UUIArtText));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(6, typeof(UUIText));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(7, typeof(UUIItem));
			this.ComponentRegisterInfos = list;
			num2 = 1;
			List<ValueTuple<int, Delegate>> list2 = new List<ValueTuple<int, Delegate>>(num2);
			CollectionsMarshal.SetCount<ValueTuple<int, Delegate>>(list2, num2);
			Span<ValueTuple<int, Delegate>> span2 = CollectionsMarshal.AsSpan<ValueTuple<int, Delegate>>(list2);
			num = 0;
			*span2[num] = new ValueTuple<int, Delegate>(0, new Action(this.OnBtnChapterClick));
			this.BtnBindInfo = list2;
		}

		// Token: 0x060413F2 RID: 267250 RVA: 0x010BCBEC File Offset: 0x010BADEC
		protected override void OnStart()
		{
			this.SeqPlayer = new LevelSequencePlayer(this.RootItem);
			UUIEffectOutline extraEffectOutline = base.GetText(6).GetOwner().GetComponentByClass(UUIEffectOutline.StaticClass()) as UUIEffectOutline;
			this.ExtraEffectOutline = extraEffectOutline;
			base.GetButton(0).OnPointEnterCallBack.Bind(new Action(this.OnPointerEnter));
		}

		// Token: 0x060413F3 RID: 267251 RVA: 0x010BCC4F File Offset: 0x010BAE4F
		protected override void OnBeforeDestroy()
		{
			base.GetButton(0).OnPointEnterCallBack.Unbind();
		}

		// Token: 0x060413F4 RID: 267252 RVA: 0x010BCC64 File Offset: 0x010BAE64
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

		// Token: 0x060413F5 RID: 267253 RVA: 0x010BCC94 File Offset: 0x010BAE94
		private EPinballChapterLevelLockStatus GetChapterLockStatus(int chapterId)
		{
			return ModelBase<PinballModel>.Instance.ActivityData.GetChapterLockStatus(chapterId);
		}

		// Token: 0x060413F6 RID: 267254 RVA: 0x010BCCA6 File Offset: 0x010BAEA6
		[NullableContext(1)]
		void IPinballChapterItem.Refresh(PinballChapterData data)
		{
			this.Refresh(data, false);
		}

		// Token: 0x060413F7 RID: 267255 RVA: 0x010BCCB0 File Offset: 0x010BAEB0
		[NullableContext(1)]
		public void Refresh(PinballChapterData data, bool defaultGray = false)
		{
			PinballChapterConfig? pinballChapterConfigById = ConfigBase<PinballConfig>.Instance.GetPinballChapterConfigById(data.ChapterId);
			bool flag = this.GetChapterLockStatus(data.ChapterId) != EPinballChapterLevelLockStatus.Activated;
			base.GetItem(4).SetUIActive(defaultGray || flag);
			UUITexture texture = base.GetTexture(2);
			UUITexture texture2 = base.GetTexture(3);
			if (texture != null)
			{
				texture.SetIsGray(defaultGray || flag);
			}
			if (texture2 != null)
			{
				texture2.SetIsGray(defaultGray || flag);
			}
			List<PinballLevelRecordData> list = new List<PinballLevelRecordData>();
			PinballActivityData activityData = ModelBase<PinballModel>.Instance.ActivityData;
			int num = 0;
			foreach (int levelId in data.LevelIds)
			{
				PinballLevelRecordData levelData = activityData.GetLevelData(levelId);
				list.Add(levelData);
				if (levelData.PassStatus != EPinballLevelPassStatus.Unfinished)
				{
					num++;
				}
			}
			this.SetRedDotVisible(activityData.HasNewChapterRedDot(data.ChapterId));
			base.GetArtText(5).SetText(num.ToString());
			UUIText text = base.GetText(6);
			Singleton<LguiUtil>.Instance.SetLocalTextNew(text, pinballChapterConfigById.Value.Name, Array.Empty<object>());
			text.outlineColor = FColor.FromHex(pinballChapterConfigById.Value.OutlineColor);
			UUIEffectOutline extraEffectOutline = this.ExtraEffectOutline;
			if (extraEffectOutline != null)
			{
				extraEffectOutline.SetOutlineColor(FColor.FromHex(pinballChapterConfigById.Value.ExOutlineColor));
			}
			this.ChapterData = data;
			this.LevelDataList = list;
		}

		// Token: 0x060413F8 RID: 267256 RVA: 0x010BCE14 File Offset: 0x010BB014
		public void SetGray(bool isSetGray)
		{
			UUITexture texture = base.GetTexture(2);
			UUITexture texture2 = base.GetTexture(3);
			if (texture != null)
			{
				texture.SetIsGray(isSetGray);
			}
			if (texture2 != null)
			{
				texture2.SetIsGray(isSetGray);
			}
		}

		// Token: 0x060413F9 RID: 267257 RVA: 0x010BCE46 File Offset: 0x010BB046
		public void SetRedDotVisible(bool isVisible)
		{
			UUIItem item = base.GetItem(7);
			if (item == null)
			{
				return;
			}
			item.SetUIActive(isVisible);
		}

		// Token: 0x060413FA RID: 267258 RVA: 0x010BCE5C File Offset: 0x010BB05C
		public UniTask PlayUnlockTweenAsync()
		{
			PinballTowerChapterItem.<PlayUnlockTweenAsync>d__16 <PlayUnlockTweenAsync>d__;
			<PlayUnlockTweenAsync>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<PlayUnlockTweenAsync>d__.<>4__this = this;
			<PlayUnlockTweenAsync>d__.<>1__state = -1;
			<PlayUnlockTweenAsync>d__.<>t__builder.Start<PinballTowerChapterItem.<PlayUnlockTweenAsync>d__16>(ref <PlayUnlockTweenAsync>d__);
			return <PlayUnlockTweenAsync>d__.<>t__builder.Task;
		}

		// Token: 0x060413FB RID: 267259 RVA: 0x010BCEA0 File Offset: 0x010BB0A0
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
			Action<PinballChapterData, List<PinballLevelRecordData>> onClickTowerBack = this.OnClickTowerBack;
			if (onClickTowerBack == null)
			{
				return;
			}
			onClickTowerBack(this.ChapterData, this.LevelDataList);
		}

		// Token: 0x060413FC RID: 267260 RVA: 0x010BCF78 File Offset: 0x010BB178
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

		// Token: 0x04024863 RID: 149603
		[Nullable(new byte[]
		{
			2,
			1,
			1,
			1
		})]
		public Action<PinballChapterData, List<PinballLevelRecordData>> OnClickTowerBack;

		// Token: 0x04024864 RID: 149604
		[Nullable(new byte[]
		{
			2,
			1,
			1
		})]
		public Action<string, string, int> OnPointerEnterChapterBack;

		// Token: 0x04024865 RID: 149605
		private LevelSequencePlayer SeqPlayer;

		// Token: 0x04024866 RID: 149606
		private UUIEffectOutline ExtraEffectOutline;

		// Token: 0x04024867 RID: 149607
		private PinballChapterData ChapterData;

		// Token: 0x04024868 RID: 149608
		[Nullable(1)]
		private List<PinballLevelRecordData> LevelDataList = new List<PinballLevelRecordData>();

		// Token: 0x0200C61A RID: 50714
		[NullableContext(0)]
		private enum EComponent
		{
			// Token: 0x0403CFA1 RID: 249761
			BtnChapter,
			// Token: 0x0403CFA2 RID: 249762
			NormalItem,
			// Token: 0x0403CFA3 RID: 249763
			TexTowerBg,
			// Token: 0x0403CFA4 RID: 249764
			TexDecoration,
			// Token: 0x0403CFA5 RID: 249765
			LockItem,
			// Token: 0x0403CFA6 RID: 249766
			ArtTxtLevelNum,
			// Token: 0x0403CFA7 RID: 249767
			TxtChapterName,
			// Token: 0x0403CFA8 RID: 249768
			RedDotItem
		}
	}
}
