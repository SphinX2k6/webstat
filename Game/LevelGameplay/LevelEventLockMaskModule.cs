using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using CSharpScript.Game.Common.Event;
using CSharpScript.Game.Ui;

namespace CSharpScript.Game.LevelGamePlay
{
	// Token: 0x02006A04 RID: 27140
	public class LevelEventLockMaskModule : IStaticVariableResetter
	{
		// Token: 0x060433CC RID: 275404 RVA: 0x01149B10 File Offset: 0x01147D10
		static LevelEventLockMaskModule()
		{
			StaticVariableRegister.RegisterAndExecute(new Action(LevelEventLockMaskModule.CreateStaticDefaultValue), new Action(LevelEventLockMaskModule.ResetStaticDefaultValue));
		}

		// Token: 0x060433CD RID: 275405 RVA: 0x01149B2F File Offset: 0x01147D2F
		public static void SetLockMask(bool state)
		{
			if (LevelEventLockMaskModule.IsLockMask == state)
			{
				return;
			}
			LevelEventLockMaskModule.IsLockMask = state;
			LevelEventLockMaskModule.RefreshLockMask(null);
			LevelEventLockMaskModule.HandleEventSystem();
		}

		// Token: 0x060433CE RID: 275406 RVA: 0x01149B4B File Offset: 0x01147D4B
		public static void Clear()
		{
			LevelEventLockMaskModule.SetLockMask(false);
		}

		// Token: 0x060433CF RID: 275407 RVA: 0x01149B54 File Offset: 0x01147D54
		private static void HandleEventSystem()
		{
			if (LevelEventLockMaskModule.IsLockMask)
			{
				EventSystem instance = Singleton<EventSystem>.Instance;
				EEventName name = EEventName.OnInputDistributeTagChanged;
				Action<IReadOnlyList<InputDistributeTag>> handle;
				if ((handle = LevelEventLockMaskModule.<>O.<0>__RefreshLockMask) == null)
				{
					handle = (LevelEventLockMaskModule.<>O.<0>__RefreshLockMask = new Action<IReadOnlyList<InputDistributeTag>>(LevelEventLockMaskModule.RefreshLockMask));
				}
				instance.Add<IReadOnlyList<InputDistributeTag>>(name, handle);
				return;
			}
			EventSystem instance2 = Singleton<EventSystem>.Instance;
			EEventName name2 = EEventName.OnInputDistributeTagChanged;
			Action<IReadOnlyList<InputDistributeTag>> handle2;
			if ((handle2 = LevelEventLockMaskModule.<>O.<0>__RefreshLockMask) == null)
			{
				handle2 = (LevelEventLockMaskModule.<>O.<0>__RefreshLockMask = new Action<IReadOnlyList<InputDistributeTag>>(LevelEventLockMaskModule.RefreshLockMask));
			}
			instance2.Remove<IReadOnlyList<InputDistributeTag>>(name2, handle2);
		}

		// Token: 0x060433D0 RID: 275408 RVA: 0x01149BC0 File Offset: 0x01147DC0
		private static void RefreshLockMask([Nullable(new byte[]
		{
			2,
			1
		})] IReadOnlyList<InputDistributeTag> _)
		{
			if (!LevelEventLockMaskModule.IsLockMask)
			{
				Singleton<UiLayer>.Instance.SetShowMaskLayer("LevelEventSetPlayerOperation", false);
				return;
			}
			InputDistributeModel instance = ModelBase<InputDistributeModel>.Instance;
			if (instance.IsTagMatchAnyCurrentInputTag("UiInputRoot.MouseInputTag", false) || instance.IsTagMatchAnyCurrentInputTag("UiInputRoot.ShortcutKeyTag", false) || instance.IsTagMatchAnyCurrentInputTag("UiInputRoot.Navigation", false))
			{
				Singleton<UiLayer>.Instance.SetShowMaskLayer("LevelEventSetPlayerOperation", false);
				return;
			}
			if (Singleton<UiManager>.Instance.IsViewShow(EUiViewName.BattleView))
			{
				Singleton<UiLayer>.Instance.SetShowMaskLayer("LevelEventSetPlayerOperation", true);
				return;
			}
			Singleton<UiLayer>.Instance.SetShowMaskLayer("LevelEventSetPlayerOperation", false);
		}

		// Token: 0x060433D1 RID: 275409 RVA: 0x01149C58 File Offset: 0x01147E58
		public static void CreateStaticDefaultValue()
		{
			LevelEventLockMaskModule.IsLockMask = false;
		}

		// Token: 0x060433D2 RID: 275410 RVA: 0x01149C60 File Offset: 0x01147E60
		public static void ResetStaticDefaultValue()
		{
			LevelEventLockMaskModule.IsLockMask = false;
		}

		// Token: 0x040257B5 RID: 153525
		private static bool IsLockMask;

		// Token: 0x0200C96E RID: 51566
		[CompilerGenerated]
		private static class <>O
		{
			// Token: 0x0403DF2A RID: 253738
			[Nullable(new byte[]
			{
				0,
				1,
				1
			})]
			public static Action<IReadOnlyList<InputDistributeTag>> <0>__RefreshLockMask;
		}
	}
}
