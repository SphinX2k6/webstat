using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Aki.Config;
using Aki.Protocol;
using CSharpScript.Game.Module.SkipInterface;
using CSharpScript.Game.Module.Util;
using UnrealEngine;

namespace CSharpScript.Game.Module.PhantomArena.Prepare.Entrance
{
	// Token: 0x020054CD RID: 21709
	[NullableContext(1)]
	[Nullable(new byte[]
	{
		0,
		1
	})]
	public class PhantomBattleTaskItem : GridProxyAbstract<PhantomArenaTaskData>
	{
		// Token: 0x060374C4 RID: 226500 RVA: 0x00E076AC File Offset: 0x00E058AC
		protected override void OnRegisterComponent()
		{
			this.ComponentRegisterInfos = new List<ValueTuple<int, Type>>
			{
				new ValueTuple<int, Type>(0, typeof(UUIButtonComponent)),
				new ValueTuple<int, Type>(1, typeof(UUIButtonComponent)),
				new ValueTuple<int, Type>(2, typeof(UUIItem)),
				new ValueTuple<int, Type>(3, typeof(UUIText)),
				new ValueTuple<int, Type>(4, typeof(UUIText)),
				new ValueTuple<int, Type>(5, typeof(UUIScrollViewWithScrollbarComponent)),
				new ValueTuple<int, Type>(6, typeof(UUIText))
			};
			this.BtnBindInfo = new List<ValueTuple<int, Delegate>>
			{
				new ValueTuple<int, Delegate>(0, new Action(this.OnClickJumpButton)),
				new ValueTuple<int, Delegate>(1, new Action(this.OnClickGetButton))
			};
		}

		// Token: 0x060374C5 RID: 226501 RVA: 0x00E07799 File Offset: 0x00E05999
		protected override void OnStart()
		{
			this.RewardScrollView = new GenericScrollViewNew<CommonItemSmallItemGrid, TItem>(base.GetScrollViewWithScrollbar(5), new Func<CommonItemSmallItemGrid>(this.CreatePropItem), null, false, null);
		}

		// Token: 0x060374C6 RID: 226502 RVA: 0x00E077BC File Offset: 0x00E059BC
		private CommonItemSmallItemGrid CreatePropItem()
		{
			return new CommonItemSmallItemGrid();
		}

		// Token: 0x060374C7 RID: 226503 RVA: 0x00E077C3 File Offset: 0x00E059C3
		private void OnClickGetButton()
		{
			ControllerBase<PhantomArenaController>.Instance.TaskAllRewardRequest(this.Data.TaskConfig.Id);
		}

		// Token: 0x060374C8 RID: 226504 RVA: 0x00E077DF File Offset: 0x00E059DF
		private void OnClickJumpButton()
		{
			if (this.Data == null || this.JumpId == 0)
			{
				return;
			}
			SkipTaskManager.RunByConfigId(this.JumpId, null);
		}

		// Token: 0x060374C9 RID: 226505 RVA: 0x00E07800 File Offset: 0x00E05A00
		public override void Refresh(PhantomArenaTaskData data, bool isSelected, int gridIndex)
		{
			this.Data = data;
			this.RewardScrollView.RefreshByData(data.Reward, null, false);
			PhantomBattleTask? taskConfigById = ConfigBase<PhantomArenaConfig>.Instance.GetTaskConfigById(this.Data.TaskConfig.Id);
			Singleton<LguiUtil>.Instance.SetLocalTextNew(base.GetText(3), taskConfigById.Value.Desc, Array.Empty<object>());
			UUIText text = base.GetText(4);
			if (text != null)
			{
				DefaultInterpolatedStringHandler defaultInterpolatedStringHandler = new DefaultInterpolatedStringHandler(1, 2);
				defaultInterpolatedStringHandler.AppendFormatted<int>(this.Data.TaskConfig.Current);
				defaultInterpolatedStringHandler.AppendLiteral("/");
				defaultInterpolatedStringHandler.AppendFormatted<int>(this.Data.TaskConfig.Target);
				text.SetText(defaultInterpolatedStringHandler.ToStringAndClear(), true);
			}
			ActivityTaskState status = this.Data.TaskConfig.Status;
			this.JumpId = taskConfigById.Value.AccessPath;
			if (status == ActivityTaskState.ActivityTaskRunning && taskConfigById.Value.AccessPath != 0)
			{
				UUIButtonComponent button = base.GetButton(0);
				if (button != null)
				{
					button.RootUIComp.Get().SetUIActive(true);
				}
			}
			else
			{
				UUIButtonComponent button2 = base.GetButton(0);
				if (button2 != null)
				{
					button2.RootUIComp.Get().SetUIActive(false);
				}
			}
			UUIItem item = base.GetItem(2);
			if (item != null)
			{
				item.SetUIActive(status == ActivityTaskState.ActivityTaskTaken);
			}
			UUIButtonComponent button3 = base.GetButton(1);
			if (button3 != null)
			{
				button3.RootUIComp.Get().SetUIActive(status == ActivityTaskState.ActivityTaskFinish);
			}
			UUIText text2 = base.GetText(6);
			if (text2 == null)
			{
				return;
			}
			text2.SetUIActive(status == ActivityTaskState.ActivityTaskRunning);
		}

		// Token: 0x0401FC69 RID: 130153
		[Nullable(new byte[]
		{
			2,
			1
		})]
		private GenericScrollViewNew<CommonItemSmallItemGrid, TItem> RewardScrollView;

		// Token: 0x0401FC6A RID: 130154
		[Nullable(2)]
		private PhantomArenaTaskData Data;

		// Token: 0x0401FC6B RID: 130155
		private int JumpId;

		// Token: 0x0200B437 RID: 46135
		[NullableContext(0)]
		private class EItemComponents
		{
			// Token: 0x04037C5E RID: 228446
			public const int JumpBtn = 0;

			// Token: 0x04037C5F RID: 228447
			public const int GetBtn = 1;

			// Token: 0x04037C60 RID: 228448
			public const int PanelDone = 2;

			// Token: 0x04037C61 RID: 228449
			public const int TxtName = 3;

			// Token: 0x04037C62 RID: 228450
			public const int ProgressText = 4;

			// Token: 0x04037C63 RID: 228451
			public const int RewardScroll = 5;

			// Token: 0x04037C64 RID: 228452
			public const int DoingText = 6;
		}
	}
}
