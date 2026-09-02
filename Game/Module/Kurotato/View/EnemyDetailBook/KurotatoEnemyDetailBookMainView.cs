using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using Aki.Config;
using CSharpScript.Game.Common.Event;
using CSharpScript.Game.Module.Kurotato.Data;
using CSharpScript.Game.Module.Util;
using CSharpScript.Game.Ui;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.CompilerServices;
using UnrealEngine;

namespace CSharpScript.Game.Module.Kurotato.View.EnemyDetailBook
{
	// Token: 0x02005AC2 RID: 23234
	[NullableContext(1)]
	[Nullable(0)]
	public class KurotatoEnemyDetailBookMainView : UiViewBase
	{
		// Token: 0x0603ABE1 RID: 240609 RVA: 0x00EE49C1 File Offset: 0x00EE2BC1
		public KurotatoEnemyDetailBookMainView(UiViewInfo info) : base(info)
		{
		}

		// Token: 0x0603ABE2 RID: 240610 RVA: 0x00EE49FC File Offset: 0x00EE2BFC
		protected unsafe override void OnRegisterComponent()
		{
			int num = 7;
			List<ValueTuple<int, Type>> list = new List<ValueTuple<int, Type>>(num);
			CollectionsMarshal.SetCount<ValueTuple<int, Type>>(list, num);
			Span<ValueTuple<int, Type>> span = CollectionsMarshal.AsSpan<ValueTuple<int, Type>>(list);
			int num2 = 0;
			*span[num2] = new ValueTuple<int, Type>(0, typeof(UUIItem));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(1, typeof(UUIHorizontalLayout));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(2, typeof(UUIItem));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(3, typeof(UUILoopScrollViewComponent));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(4, typeof(UUIItem));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(5, typeof(UUIItem));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(6, typeof(UUIInturnAnimController));
			this.ComponentRegisterInfos = list;
		}

		// Token: 0x0603ABE3 RID: 240611 RVA: 0x00EE4B0C File Offset: 0x00EE2D0C
		protected override UniTask OnBeforeStartAsync()
		{
			KurotatoEnemyDetailBookMainView.<OnBeforeStartAsync>d__15 <OnBeforeStartAsync>d__;
			<OnBeforeStartAsync>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<OnBeforeStartAsync>d__.<>4__this = this;
			<OnBeforeStartAsync>d__.<>1__state = -1;
			<OnBeforeStartAsync>d__.<>t__builder.Start<KurotatoEnemyDetailBookMainView.<OnBeforeStartAsync>d__15>(ref <OnBeforeStartAsync>d__);
			return <OnBeforeStartAsync>d__.<>t__builder.Task;
		}

		// Token: 0x0603ABE4 RID: 240612 RVA: 0x00EE4B4F File Offset: 0x00EE2D4F
		protected override void OnAddEventListener()
		{
			Singleton<EventSystem>.Instance.Add<KurotatoEnemyData>(EEventName.KurotatoEnemyDetailBookGridItemClick, new Action<KurotatoEnemyData>(this.OnClickGridItem));
		}

		// Token: 0x0603ABE5 RID: 240613 RVA: 0x00EE4B6D File Offset: 0x00EE2D6D
		protected override void OnRemoveEventListener()
		{
			Singleton<EventSystem>.Instance.Remove<KurotatoEnemyData>(EEventName.KurotatoEnemyDetailBookGridItemClick, new Action<KurotatoEnemyData>(this.OnClickGridItem));
		}

		// Token: 0x0603ABE6 RID: 240614 RVA: 0x00EE4B8C File Offset: 0x00EE2D8C
		protected override void OnBeforeShow()
		{
			List<KurotatoEnemyDetailBookBigItemData> list;
			if (this.BigItemDataListMap.TryGetValue(EKurotatoEnemyDetailBookTabAllOrWave.Wave, out list) && list.Count > 0)
			{
				int num = Math.Max(this.InitTargetWave - 1, 0);
				if (num < list.Count)
				{
					List<KurotatoEnemyData> monsterGridItemDataList = list[num].GetMonsterGridItemDataList();
					if (monsterGridItemDataList.Count > 0)
					{
						this.CurSelectedDataInWave = monsterGridItemDataList[0];
					}
				}
			}
			List<KurotatoEnemyDetailBookBigItemData> list2;
			if (this.BigItemDataListMap.TryGetValue(EKurotatoEnemyDetailBookTabAllOrWave.All, out list2) && list2.Count > 0)
			{
				List<KurotatoEnemyData> monsterGridItemDataList2 = list2[0].GetMonsterGridItemDataList();
				if (monsterGridItemDataList2.Count > 0)
				{
					this.CurSelectedDataInAll = monsterGridItemDataList2[0];
				}
			}
			if (this.InitTargetWave > 0)
			{
				this.OnClickTabTog(EKurotatoEnemyDetailBookTabAllOrWave.Wave);
				return;
			}
			this.OnClickTabTog(EKurotatoEnemyDetailBookTabAllOrWave.All);
		}

		// Token: 0x0603ABE7 RID: 240615 RVA: 0x00EE4C44 File Offset: 0x00EE2E44
		private KurotatoEnemyDetailBookTabTog CreateTabTogItem()
		{
			return new KurotatoEnemyDetailBookTabTog
			{
				OnTogClickCallBack = new Action<EKurotatoEnemyDetailBookTabAllOrWave>(this.OnClickTabTog),
				CanExecuteChangeFunc = new Func<int, bool>(this.CanTabTogChange)
			};
		}

		// Token: 0x0603ABE8 RID: 240616 RVA: 0x00EE4C6F File Offset: 0x00EE2E6F
		private KurotatoEnemyDetailBookBigItem CreateBigItem()
		{
			return new KurotatoEnemyDetailBookBigItem
			{
				CanGridItemExecuteChangeCb = new Func<KurotatoEnemyData, bool>(this.CanGridItemExecuteChange)
			};
		}

		// Token: 0x0603ABE9 RID: 240617 RVA: 0x00EE4C88 File Offset: 0x00EE2E88
		private void OnClickTabTog(EKurotatoEnemyDetailBookTabAllOrWave data)
		{
			this.CurShowAllOrWave = data;
			GenericLayout<KurotatoEnemyDetailBookTabTog, EKurotatoEnemyDetailBookTabAllOrWave> tabTogLayout = this.TabTogLayout;
			if (tabTogLayout != null)
			{
				tabTogLayout.SelectGridProxy((int)data, false);
			}
			LevelSequencePlayer levelSequencePlayer = this.LevelSequencePlayer;
			if (levelSequencePlayer != null)
			{
				levelSequencePlayer.StopSequenceByKey("Switch", false, true);
			}
			LevelSequencePlayer levelSequencePlayer2 = this.LevelSequencePlayer;
			if (levelSequencePlayer2 != null)
			{
				levelSequencePlayer2.PlayLevelSequenceByName("Switch", false, null, false);
			}
			this.RefreshView();
		}

		// Token: 0x0603ABEA RID: 240618 RVA: 0x00EE4CF0 File Offset: 0x00EE2EF0
		private bool CanTabTogChange(int gridIndex)
		{
			GenericLayout<KurotatoEnemyDetailBookTabTog, EKurotatoEnemyDetailBookTabAllOrWave> tabTogLayout = this.TabTogLayout;
			int? num = (tabTogLayout != null) ? new int?(tabTogLayout.GetSelectedGridIndex()) : null;
			return !(num.GetValueOrDefault() == gridIndex & num != null);
		}

		// Token: 0x0603ABEB RID: 240619 RVA: 0x00EE4D34 File Offset: 0x00EE2F34
		private bool CanGridItemExecuteChange(KurotatoEnemyData data)
		{
			EKurotatoEnemyDetailBookTabAllOrWave curShowAllOrWave = this.CurShowAllOrWave;
			if (curShowAllOrWave != EKurotatoEnemyDetailBookTabAllOrWave.All)
			{
				return curShowAllOrWave == EKurotatoEnemyDetailBookTabAllOrWave.Wave && this.CurSelectedDataInWave != data;
			}
			return this.CurSelectedDataInAll != data;
		}

		// Token: 0x0603ABEC RID: 240620 RVA: 0x00EE4D6C File Offset: 0x00EE2F6C
		private void OnClickGridItem(KurotatoEnemyData data)
		{
			this.SetCurSelectedData(data);
			int displayGridStartIndex = this.ScrollView.GetDisplayGridStartIndex();
			int displayGridEndIndex = this.ScrollView.GetDisplayGridEndIndex();
			for (int i = displayGridStartIndex; i <= displayGridEndIndex; i++)
			{
				KurotatoEnemyDetailBookBigItem kurotatoEnemyDetailBookBigItem = this.ScrollView.UnsafeGetGridProxy(i, false);
				if (kurotatoEnemyDetailBookBigItem != null)
				{
					kurotatoEnemyDetailBookBigItem.CheckSelectedStateIsInBigItem(data);
				}
			}
			this.RefreshDetailInfoView();
		}

		// Token: 0x0603ABED RID: 240621 RVA: 0x00EE4DC0 File Offset: 0x00EE2FC0
		private void CreateBigItemDataList()
		{
			List<KurotatoEnemyDetailBookBigItemData> list = new List<KurotatoEnemyDetailBookBigItemData>();
			List<KurotatoEnemyDetailBookBigItemData> list2 = new List<KurotatoEnemyDetailBookBigItemData>();
			for (int i = 3; i >= 1; i--)
			{
				KurotatoEnemyDetailBookBigItemDataAll kurotatoEnemyDetailBookBigItemDataAll = new KurotatoEnemyDetailBookBigItemDataAll(this.CurTargetLevel, i);
				if (kurotatoEnemyDetailBookBigItemDataAll.GetMonsterGridItemDataList().Count > 0)
				{
					list.Add(kurotatoEnemyDetailBookBigItemDataAll);
				}
			}
			List<KurotatoWave> waveByLevelId = ConfigBase<KurotatoConfig>.Instance.GetWaveByLevelId(this.CurTargetLevel);
			if (waveByLevelId == null || waveByLevelId.Count == 0)
			{
				return;
			}
			foreach (KurotatoWave kurotatoWave in waveByLevelId)
			{
				if (kurotatoWave.WaveType != 1)
				{
					int wave = kurotatoWave.Wave;
					KurotatoEnemyDetailBookBigItemDataWave item = new KurotatoEnemyDetailBookBigItemDataWave(this.CurTargetLevel, wave, this.InitTargetWave);
					list2.Add(item);
				}
			}
			this.BigItemDataListMap[EKurotatoEnemyDetailBookTabAllOrWave.All] = list;
			this.BigItemDataListMap[EKurotatoEnemyDetailBookTabAllOrWave.Wave] = list2;
		}

		// Token: 0x0603ABEE RID: 240622 RVA: 0x00EE4EB0 File Offset: 0x00EE30B0
		[NullableContext(2)]
		private void SetCurSelectedData(KurotatoEnemyData data)
		{
			EKurotatoEnemyDetailBookTabAllOrWave curShowAllOrWave = this.CurShowAllOrWave;
			if (curShowAllOrWave != EKurotatoEnemyDetailBookTabAllOrWave.All)
			{
				if (curShowAllOrWave == EKurotatoEnemyDetailBookTabAllOrWave.Wave)
				{
					this.CurSelectedDataInWave = data;
				}
			}
			else
			{
				this.CurSelectedDataInAll = data;
			}
			foreach (KurotatoEnemyDetailBookBigItemData kurotatoEnemyDetailBookBigItemData in this.BigItemDataListMap[this.CurShowAllOrWave])
			{
				kurotatoEnemyDetailBookBigItemData.CurSelectedGridItemData = null;
				if (kurotatoEnemyDetailBookBigItemData.GetMonsterGridItemDataList().Contains(data))
				{
					kurotatoEnemyDetailBookBigItemData.CurSelectedGridItemData = data;
				}
			}
		}

		// Token: 0x0603ABEF RID: 240623 RVA: 0x00EE4F44 File Offset: 0x00EE3144
		private void RefreshView()
		{
			List<KurotatoEnemyDetailBookBigItemData> data = this.BigItemDataListMap[this.CurShowAllOrWave];
			this.ScrollView.RefreshByData(data, false, delegate
			{
				EKurotatoEnemyDetailBookTabAllOrWave curShowAllOrWave = this.CurShowAllOrWave;
				if (curShowAllOrWave == EKurotatoEnemyDetailBookTabAllOrWave.All)
				{
					this.OnClickGridItem(this.CurSelectedDataInAll);
					return;
				}
				if (curShowAllOrWave != EKurotatoEnemyDetailBookTabAllOrWave.Wave)
				{
					return;
				}
				this.OnClickGridItem(this.CurSelectedDataInWave);
				this.ScrollView.ScrollToGridIndexLate(Math.Max(this.InitTargetWave - 1, 0), false);
			}, false);
		}

		// Token: 0x0603ABF0 RID: 240624 RVA: 0x00EE4F80 File Offset: 0x00EE3180
		private void RefreshDetailInfoView()
		{
			KurotatoEnemyData monsterData = (this.CurShowAllOrWave == EKurotatoEnemyDetailBookTabAllOrWave.All) ? this.CurSelectedDataInAll : this.CurSelectedDataInWave;
			KurotatoEnemyDetailBookInfoPanel enemyInfoPanel = this.EnemyInfoPanel;
			if (enemyInfoPanel == null)
			{
				return;
			}
			enemyInfoPanel.RefreshMonsterInfoShow(monsterData);
		}

		// Token: 0x0603ABF1 RID: 240625 RVA: 0x00EE4FB5 File Offset: 0x00EE31B5
		private void OnCloseClick()
		{
			base.CloseMe(null);
		}

		// Token: 0x04021369 RID: 136041
		[Nullable(2)]
		private PopupCaptionItem CaptionItem;

		// Token: 0x0402136A RID: 136042
		private int CurTargetLevel = 1001;

		// Token: 0x0402136B RID: 136043
		private EKurotatoEnemyDetailBookTabAllOrWave CurShowAllOrWave;

		// Token: 0x0402136C RID: 136044
		private int InitTargetWave;

		// Token: 0x0402136D RID: 136045
		[Nullable(new byte[]
		{
			2,
			1
		})]
		private GenericLayout<KurotatoEnemyDetailBookTabTog, EKurotatoEnemyDetailBookTabAllOrWave> TabTogLayout;

		// Token: 0x0402136E RID: 136046
		private readonly List<EKurotatoEnemyDetailBookTabAllOrWave> TabTogDataList = new List<EKurotatoEnemyDetailBookTabAllOrWave>
		{
			EKurotatoEnemyDetailBookTabAllOrWave.All,
			EKurotatoEnemyDetailBookTabAllOrWave.Wave
		};

		// Token: 0x0402136F RID: 136047
		[Nullable(new byte[]
		{
			2,
			1,
			1
		})]
		protected LoopScrollView<KurotatoEnemyDetailBookBigItem, KurotatoEnemyDetailBookBigItemData> ScrollView;

		// Token: 0x04021370 RID: 136048
		protected Dictionary<EKurotatoEnemyDetailBookTabAllOrWave, List<KurotatoEnemyDetailBookBigItemData>> BigItemDataListMap = new Dictionary<EKurotatoEnemyDetailBookTabAllOrWave, List<KurotatoEnemyDetailBookBigItemData>>();

		// Token: 0x04021371 RID: 136049
		[Nullable(2)]
		private KurotatoEnemyData CurSelectedDataInAll;

		// Token: 0x04021372 RID: 136050
		[Nullable(2)]
		private KurotatoEnemyData CurSelectedDataInWave;

		// Token: 0x04021373 RID: 136051
		[Nullable(2)]
		private KurotatoEnemyDetailBookInfoPanel EnemyInfoPanel;

		// Token: 0x04021374 RID: 136052
		[Nullable(2)]
		private LevelSequencePlayer LevelSequencePlayer;

		// Token: 0x0200BAD6 RID: 47830
		[NullableContext(0)]
		private class EComponent
		{
			// Token: 0x04039AC6 RID: 236230
			public const int CaptionItem = 0;

			// Token: 0x04039AC7 RID: 236231
			public const int PanelTab = 1;

			// Token: 0x04039AC8 RID: 236232
			public const int ToggleTab = 2;

			// Token: 0x04039AC9 RID: 236233
			public const int MainScrollView = 3;

			// Token: 0x04039ACA RID: 236234
			public const int NodeEnemyItemGrid = 4;

			// Token: 0x04039ACB RID: 236235
			public const int PanelEnemyInfo = 5;

			// Token: 0x04039ACC RID: 236236
			public const int Content = 6;
		}
	}
}
