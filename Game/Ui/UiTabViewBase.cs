using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using CSharpScript.Game.Common.Event;
using UnrealEngine;

namespace CSharpScript.Game.Ui
{
	// Token: 0x020049B2 RID: 18866
	[NullableContext(1)]
	[Nullable(0)]
	public abstract class UiTabViewBase : UiPanelBase
	{
		// Token: 0x060314EB RID: 201963 RVA: 0x00C45DF3 File Offset: 0x00C43FF3
		public void SetTabViewName(EUiTabViewName tabViewName)
		{
			this.TabViewName = new EUiTabViewName?(tabViewName);
		}

		// Token: 0x060314EC RID: 201964 RVA: 0x00C45E01 File Offset: 0x00C44001
		protected override void OnBeforeShowImplement()
		{
			if (this.TickId == -1)
			{
				this.TickId = Singleton<TickSystem>.Instance.Add(new Action<float>(this.TickHandler), "TabViewTick", ETickingGroup.TG_PrePhysics, true, 0, false).Id;
			}
			this.AddEventListener();
		}

		// Token: 0x060314ED RID: 201965 RVA: 0x00C45E3C File Offset: 0x00C4403C
		protected override void OnAfterHideImplement()
		{
			if (this.TickId != -1)
			{
				Singleton<TickSystem>.Instance.Remove(this.TickId);
				this.TickId = -1;
			}
			Singleton<EventSystem>.Instance.Emit<EUiTabViewName>(EEventName.CloseTabView, this.TabViewName.Value);
			this.RemoveEventListener();
		}

		// Token: 0x060314EE RID: 201966 RVA: 0x00C45E88 File Offset: 0x00C44088
		protected virtual void AddEventListener()
		{
		}

		// Token: 0x060314EF RID: 201967 RVA: 0x00C45E8A File Offset: 0x00C4408A
		protected virtual void RemoveEventListener()
		{
		}

		// Token: 0x060314F0 RID: 201968 RVA: 0x00C45E8C File Offset: 0x00C4408C
		protected override void OnBeforeCreateImplement()
		{
			this.UiViewSequence = new UiBehaviorLevelSequence(this);
			base.AddUiBehavior(this.UiViewSequence);
		}

		// Token: 0x060314F1 RID: 201969 RVA: 0x00C45EA8 File Offset: 0x00C440A8
		protected override void OnStartImplement()
		{
			this.InitBehavior();
			this.OnInitBehaviour();
			foreach (TOperation toperation in this.OperationList)
			{
				toperation();
			}
			this.OperationList.Clear();
			this.BeginBehavior();
		}

		// Token: 0x060314F2 RID: 201970 RVA: 0x00C45F18 File Offset: 0x00C44118
		private void TickHandler(float deltaTime)
		{
			this.OnTickUiTabViewBase(deltaTime);
		}

		// Token: 0x060314F3 RID: 201971 RVA: 0x00C45F24 File Offset: 0x00C44124
		public T AddUiTabViewBehavior<[Nullable(0)] T>() where T : UiTabViewBehavior, new()
		{
			Type typeFromHandle = typeof(T);
			UiTabViewBehavior uiTabViewBehavior;
			if (!this.TabBehaviorMap.TryGetValue(typeFromHandle, out uiTabViewBehavior))
			{
				uiTabViewBehavior = Activator.CreateInstance<T>();
				this.TabBehaviorMap[typeFromHandle] = uiTabViewBehavior;
			}
			else
			{
				Singleton<Log>.Instance.Error(ELogModule.UiTabModule, ELogAuthor.XXJ, "功能模块添加重复,查看是否重复添加", default(ReadOnlySpan<ValueTuple<string, object>>));
			}
			return (T)((object)uiTabViewBehavior);
		}

		// Token: 0x060314F4 RID: 201972 RVA: 0x00C45F88 File Offset: 0x00C44188
		public T GetTabBehavior<[Nullable(0)] T>() where T : UiTabViewBehavior
		{
			Type typeFromHandle = typeof(T);
			UiTabViewBehavior uiTabViewBehavior;
			if (this.TabBehaviorMap.TryGetValue(typeFromHandle, out uiTabViewBehavior))
			{
				return (T)((object)uiTabViewBehavior);
			}
			return default(T);
		}

		// Token: 0x060314F5 RID: 201973 RVA: 0x00C45FC0 File Offset: 0x00C441C0
		protected override void OnAfterShowImplement()
		{
			Singleton<EventSystem>.Instance.Emit<EUiTabViewName?, UiTabViewBase>(EEventName.OpenTabView, this.TabViewName, this);
		}

		// Token: 0x060314F6 RID: 201974 RVA: 0x00C45FD8 File Offset: 0x00C441D8
		private void InitBehavior()
		{
			foreach (UiTabViewBehavior uiTabViewBehavior in this.TabBehaviorMap.Values)
			{
				uiTabViewBehavior.Init();
			}
		}

		// Token: 0x060314F7 RID: 201975 RVA: 0x00C46030 File Offset: 0x00C44230
		private void BeginBehavior()
		{
			foreach (UiTabViewBehavior uiTabViewBehavior in this.TabBehaviorMap.Values)
			{
				uiTabViewBehavior.Begin();
			}
		}

		// Token: 0x060314F8 RID: 201976 RVA: 0x00C46088 File Offset: 0x00C44288
		private void ShowBehaviorFromView()
		{
			foreach (UiTabViewBehavior uiTabViewBehavior in this.TabBehaviorMap.Values)
			{
				uiTabViewBehavior.ShowFromView();
			}
		}

		// Token: 0x060314F9 RID: 201977 RVA: 0x00C460E0 File Offset: 0x00C442E0
		private void ShowBehaviorFromToggle()
		{
			foreach (UiTabViewBehavior uiTabViewBehavior in this.TabBehaviorMap.Values)
			{
				uiTabViewBehavior.ShowFromToggle();
			}
		}

		// Token: 0x060314FA RID: 201978 RVA: 0x00C46138 File Offset: 0x00C44338
		private void HideBehavior()
		{
			foreach (UiTabViewBehavior uiTabViewBehavior in this.TabBehaviorMap.Values)
			{
				uiTabViewBehavior.Hide();
			}
		}

		// Token: 0x060314FB RID: 201979 RVA: 0x00C46190 File Offset: 0x00C44390
		private void DestroyBehavior()
		{
			foreach (UiTabViewBehavior uiTabViewBehavior in this.TabBehaviorMap.Values)
			{
				uiTabViewBehavior.Destroy();
			}
		}

		// Token: 0x060314FC RID: 201980 RVA: 0x00C461E8 File Offset: 0x00C443E8
		protected virtual void OnInitBehaviour()
		{
		}

		// Token: 0x060314FD RID: 201981 RVA: 0x00C461EA File Offset: 0x00C443EA
		protected virtual void OnHideUiTabViewBase(bool fromToggle)
		{
		}

		// Token: 0x060314FE RID: 201982 RVA: 0x00C461EC File Offset: 0x00C443EC
		protected virtual void OnTickUiTabViewBase(float deltaTime)
		{
		}

		// Token: 0x060314FF RID: 201983 RVA: 0x00C461EE File Offset: 0x00C443EE
		protected virtual void OnShowUiTabViewFromToggle()
		{
		}

		// Token: 0x06031500 RID: 201984 RVA: 0x00C461F0 File Offset: 0x00C443F0
		protected virtual void OnShowUiTabViewFromView()
		{
		}

		// Token: 0x06031501 RID: 201985 RVA: 0x00C461F2 File Offset: 0x00C443F2
		public void ShowUiTabViewFromToggle()
		{
			base.Show(null);
			this.OnShowUiTabViewFromToggle();
			this.ShowBehaviorFromToggle();
			this.IsFirstShow = false;
		}

		// Token: 0x06031502 RID: 201986 RVA: 0x00C4620E File Offset: 0x00C4440E
		public void ShowUiTabViewFromView()
		{
			base.Show(null);
			this.OnShowUiTabViewFromView();
			this.ShowBehaviorFromView();
			this.IsFirstShow = false;
		}

		// Token: 0x06031503 RID: 201987 RVA: 0x00C4622A File Offset: 0x00C4442A
		public void HideUiTabView(bool fromToggle)
		{
			base.Hide(null);
			this.OnHideUiTabViewBase(fromToggle);
			this.HideBehavior();
		}

		// Token: 0x06031504 RID: 201988 RVA: 0x00C46240 File Offset: 0x00C44440
		protected override void OnBeforeDestroyImplement()
		{
			this.DestroyBehavior();
		}

		// Token: 0x06031505 RID: 201989 RVA: 0x00C46248 File Offset: 0x00C44448
		public void SetParams(object param)
		{
			this.Params = param;
		}

		// Token: 0x06031506 RID: 201990 RVA: 0x00C46251 File Offset: 0x00C44451
		public void SetExtraParams(object extraParams)
		{
			this.ExtraParams = extraParams;
		}

		// Token: 0x06031507 RID: 201991 RVA: 0x00C4625C File Offset: 0x00C4445C
		public string GetViewName()
		{
			EUiTabViewName? tabViewName = this.TabViewName;
			if (tabViewName == null)
			{
				return null;
			}
			return tabViewName.GetValueOrDefault();
		}

		// Token: 0x06031508 RID: 201992 RVA: 0x00C46287 File Offset: 0x00C44487
		public void CancelAsyncLoad()
		{
			base.ClearUiPrefabLoadModule();
		}

		// Token: 0x0401C567 RID: 116071
		private int TickId = -1;

		// Token: 0x0401C568 RID: 116072
		protected bool IsFirstShow = true;

		// Token: 0x0401C569 RID: 116073
		[Nullable(2)]
		protected object Params;

		// Token: 0x0401C56A RID: 116074
		private readonly Dictionary<Type, UiTabViewBehavior> TabBehaviorMap = new Dictionary<Type, UiTabViewBehavior>();

		// Token: 0x0401C56B RID: 116075
		protected List<TOperation> OperationList = new List<TOperation>();

		// Token: 0x0401C56C RID: 116076
		[Nullable(2)]
		protected object ExtraParams;

		// Token: 0x0401C56D RID: 116077
		[Nullable(2)]
		public UiBehaviorLevelSequence UiViewSequence;

		// Token: 0x0401C56E RID: 116078
		private EUiTabViewName? TabViewName;
	}
}
