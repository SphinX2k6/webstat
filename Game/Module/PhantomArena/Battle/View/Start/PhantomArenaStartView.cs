using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using CSharpScript.Game.Module.PhantomArena.Battle.Model;
using CSharpScript.Game.Ui;
using UnrealEngine;

namespace CSharpScript.Game.Module.PhantomArena.Battle.View.Start
{
	// Token: 0x020055B4 RID: 21940
	[NullableContext(1)]
	[Nullable(0)]
	public class PhantomArenaStartView : UiViewBase, IUiViewResource
	{
		// Token: 0x06037DCC RID: 228812 RVA: 0x00E27881 File Offset: 0x00E25A81
		public PhantomArenaStartView(UiViewInfo uiViewInfo) : base(uiViewInfo)
		{
		}

		// Token: 0x06037DCD RID: 228813 RVA: 0x00E2788A File Offset: 0x00E25A8A
		protected override void OnRegisterComponent()
		{
			this.ComponentRegisterInfos = new List<ValueTuple<int, Type>>
			{
				new ValueTuple<int, Type>(0, typeof(UUIText)),
				new ValueTuple<int, Type>(1, typeof(UUIText))
			};
		}

		// Token: 0x06037DCE RID: 228814 RVA: 0x00E278C4 File Offset: 0x00E25AC4
		protected override void OnStart()
		{
			this.Data = (this.OpenParam as IPhantomArenaStartViewData);
			int round = ModelBase<PhantomArenaBattleModel>.Instance.Round;
			Singleton<LguiUtil>.Instance.SetLocalTextNew(base.GetText(1), this.Data.ContentTextId, Array.Empty<object>());
			Singleton<LguiUtil>.Instance.SetLocalTextNew(base.GetText(0), "PhantomBattle_1030", new <>z__ReadOnlySingleElementList<object>(round));
			Log instance = Singleton<Log>.Instance;
			ELogModule module = ELogModule.PhantomArena;
			ELogAuthor author = ELogAuthor.XXJ;
			string message = "回合开始";
			ValueTuple<string, object> valueTuple = new ValueTuple<string, object>("回合数", round);
			instance.Info(module, author, message, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple));
			this.Handle = TimerSystem.GameplayTimeInstance.Delay(delegate(float _)
			{
				this.RemoveHandle();
				base.CloseMe(null);
			}, 2000f, null, null, true, 1f);
		}

		// Token: 0x06037DCF RID: 228815 RVA: 0x00E27987 File Offset: 0x00E25B87
		protected override void OnBeforeDestroy()
		{
			this.RemoveHandle();
			IPhantomArenaStartViewData data = this.Data;
			if (data == null)
			{
				return;
			}
			Action callback = data.Callback;
			if (callback == null)
			{
				return;
			}
			callback();
		}

		// Token: 0x06037DD0 RID: 228816 RVA: 0x00E279A9 File Offset: 0x00E25BA9
		private void RemoveHandle()
		{
			if (this.Handle != null)
			{
				TimerSystem.GameplayTimeInstance.Remove(this.Handle);
				this.Handle = null;
			}
		}

		// Token: 0x06037DD1 RID: 228817 RVA: 0x00E279CB File Offset: 0x00E25BCB
		public string GetExtraResourceId([Nullable(2)] object param)
		{
			IPhantomArenaStartViewData phantomArenaStartViewData = param as IPhantomArenaStartViewData;
			if (phantomArenaStartViewData != null && phantomArenaStartViewData.IsOwn)
			{
				return "UiItem_BattleStart1";
			}
			return "UiItem_BattleStart";
		}

		// Token: 0x0401FF97 RID: 130967
		private const int SHOW_TIME = 2000;

		// Token: 0x0401FF98 RID: 130968
		private TimerHandle Handle;

		// Token: 0x0401FF99 RID: 130969
		private IPhantomArenaStartViewData Data;

		// Token: 0x0200B572 RID: 46450
		[NullableContext(0)]
		private class EComponentDefine
		{
			// Token: 0x04038274 RID: 230004
			public const int TimeText = 0;

			// Token: 0x04038275 RID: 230005
			public const int TitleText = 1;
		}
	}
}
