using System;
using System.Runtime.CompilerServices;
using CSharpScript.Game.Module.Item;
using CSharpScript.Game.Ui;

namespace CSharpScript.Game.Module.RoleUi.RoleDevelop.RoleDevelopWorldDropEnoughTips
{
	// Token: 0x020050D3 RID: 20691
	public class RoleDevelopWorldDropEnoughTipsController : IStaticVariableResetter
	{
		// Token: 0x06035511 RID: 218385 RVA: 0x00D6085C File Offset: 0x00D5EA5C
		static RoleDevelopWorldDropEnoughTipsController()
		{
			StaticVariableRegister.RegisterAndExecute(new Action(RoleDevelopWorldDropEnoughTipsController.CreateStaticDefaultValue), new Action(RoleDevelopWorldDropEnoughTipsController.ResetStaticDefaultValue));
		}

		// Token: 0x06035512 RID: 218386 RVA: 0x00D6087B File Offset: 0x00D5EA7B
		public static void CreateStaticDefaultValue()
		{
			RoleDevelopWorldDropEnoughTipsController.WaitTimerHandle = null;
		}

		// Token: 0x06035513 RID: 218387 RVA: 0x00D60883 File Offset: 0x00D5EA83
		public static void ResetStaticDefaultValue()
		{
			RoleDevelopWorldDropEnoughTipsController.WaitTimerHandle = null;
		}

		// Token: 0x06035514 RID: 218388 RVA: 0x00D6088B File Offset: 0x00D5EA8B
		public static void TryShow(int itemId, int displayItemId)
		{
			if (!ModelBase<RoleDevelopModel>.Instance.EnqueueWorldDropTip(itemId, displayItemId))
			{
				return;
			}
			RoleDevelopWorldDropEnoughTipsController.TryOpenView();
		}

		// Token: 0x06035515 RID: 218389 RVA: 0x00D608A4 File Offset: 0x00D5EAA4
		private static void TryOpenView()
		{
			RoleDevelopModel instance = ModelBase<RoleDevelopModel>.Instance;
			if (instance.IsWorldDropTipShowing || !instance.HasPendingWorldDropTip())
			{
				return;
			}
			if (!RoleDevelopWorldDropEnoughTipsController.CanOpenNow())
			{
				RoleDevelopWorldDropEnoughTipsController.StartWaitTimer();
				return;
			}
			if (!instance.AdvanceWorldDropTipToNext())
			{
				return;
			}
			Singleton<UiManager>.Instance.OpenView(EUiViewName.RoleDevelopWorldDropEnoughTips, null, null);
		}

		// Token: 0x06035516 RID: 218390 RVA: 0x00D608F0 File Offset: 0x00D5EAF0
		private static bool CanOpenNow()
		{
			ItemModel instance = ModelBase<ItemModel>.Instance;
			return instance.IsWaitItemListEmpty() && instance.IsWaitPhantomListEmpty() && instance.IsWaitVillageInfrTreeListEmpty() && !Singleton<UiManager>.Instance.IsViewOpen(EUiViewName.NewItemTipsView) && !Singleton<UiManager>.Instance.IsViewOpen(EUiViewName.PhantomTipsView) && !Singleton<UiManager>.Instance.IsViewOpen(EUiViewName.VillageInfrNewTipsView);
		}

		// Token: 0x06035517 RID: 218391 RVA: 0x00D60954 File Offset: 0x00D5EB54
		private static void StartWaitTimer()
		{
			if (RoleDevelopWorldDropEnoughTipsController.WaitTimerHandle != null)
			{
				return;
			}
			TimerSystemInstance instance = TimerSystem.Instance;
			TTimerAction action;
			if ((action = RoleDevelopWorldDropEnoughTipsController.<>O.<0>__OnWaitTick) == null)
			{
				action = (RoleDevelopWorldDropEnoughTipsController.<>O.<0>__OnWaitTick = new TTimerAction(RoleDevelopWorldDropEnoughTipsController.OnWaitTick));
			}
			RoleDevelopWorldDropEnoughTipsController.WaitTimerHandle = instance.Forever(action, 500f, 1f, null, "RoleDevelopWorldDropEnoughTips.WaitNewItemTips", true);
		}

		// Token: 0x06035518 RID: 218392 RVA: 0x00D609A4 File Offset: 0x00D5EBA4
		private static void StopWaitTimer()
		{
			TimerHandle waitTimerHandle = RoleDevelopWorldDropEnoughTipsController.WaitTimerHandle;
			if (waitTimerHandle == null)
			{
				return;
			}
			RoleDevelopWorldDropEnoughTipsController.WaitTimerHandle = null;
			waitTimerHandle.Remove();
		}

		// Token: 0x06035519 RID: 218393 RVA: 0x00D609C8 File Offset: 0x00D5EBC8
		private static void OnWaitTick(float delta)
		{
			RoleDevelopModel instance = ModelBase<RoleDevelopModel>.Instance;
			if (instance == null || !instance.HasPendingWorldDropTip())
			{
				RoleDevelopWorldDropEnoughTipsController.StopWaitTimer();
				return;
			}
			if (!RoleDevelopWorldDropEnoughTipsController.CanOpenNow())
			{
				return;
			}
			RoleDevelopWorldDropEnoughTipsController.StopWaitTimer();
			RoleDevelopWorldDropEnoughTipsController.TryOpenView();
		}

		// Token: 0x0603551A RID: 218394 RVA: 0x00D60A00 File Offset: 0x00D5EC00
		public static int? GetCurrentDisplayItemId()
		{
			RoleDevelopWorldDropTipEntry worldDropTipCurrentEntry = ModelBase<RoleDevelopModel>.Instance.GetWorldDropTipCurrentEntry();
			if (worldDropTipCurrentEntry == null)
			{
				return null;
			}
			return new int?(worldDropTipCurrentEntry.DisplayItemId);
		}

		// Token: 0x0603551B RID: 218395 RVA: 0x00D60A30 File Offset: 0x00D5EC30
		public static void TryShowNext()
		{
			RoleDevelopModel instance = ModelBase<RoleDevelopModel>.Instance;
			if (instance != null)
			{
				instance.IsWorldDropTipShowing = false;
			}
			RoleDevelopWorldDropEnoughTipsController.TryOpenView();
		}

		// Token: 0x0401EA9D RID: 125597
		private const float WAIT_INTERVAL_MS = 500f;

		// Token: 0x0401EA9E RID: 125598
		[Nullable(2)]
		private static TimerHandle WaitTimerHandle;

		// Token: 0x0200B072 RID: 45170
		[CompilerGenerated]
		private static class <>O
		{
			// Token: 0x04036C01 RID: 224257
			public static TTimerAction <0>__OnWaitTick;
		}
	}
}
