using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using CSharpScript.Game.Common.Event;
using CSharpScript.Game.Module.BattleUi;
using CSharpScript.Game.Module.RoleMorph.Handle;
using CSharpScript.Game.Ui;

namespace CSharpScript.Game.Module.RoleMorph
{
	// Token: 0x020050DF RID: 20703
	[NullableContext(1)]
	[Nullable(new byte[]
	{
		0,
		1
	})]
	[Controller(0)]
	public class RoleMorphController : UiControllerBase<RoleMorphController>
	{
		// Token: 0x060355F3 RID: 218611 RVA: 0x00D63230 File Offset: 0x00D61430
		protected override bool OnLeaveLevel()
		{
			if (this.CurMorphHandle != null)
			{
				this.CurMorphHandle.EndMorph();
				this.CurMorphHandle = null;
			}
			return true;
		}

		// Token: 0x060355F4 RID: 218612 RVA: 0x00D6324D File Offset: 0x00D6144D
		protected override void OnAddEvents()
		{
			Singleton<EventSystem>.Instance.Add<int, int>(EEventName.BattleUiCurRoleDataChanged, new Action<int, int>(this.OnChangeRole));
		}

		// Token: 0x060355F5 RID: 218613 RVA: 0x00D6326B File Offset: 0x00D6146B
		protected override void OnRemoveEvents()
		{
			Singleton<EventSystem>.Instance.Remove<int, int>(EEventName.BattleUiCurRoleDataChanged, new Action<int, int>(this.OnChangeRole));
		}

		// Token: 0x060355F6 RID: 218614 RVA: 0x00D6328C File Offset: 0x00D6148C
		private void OnChangeRole(int _1, int _2)
		{
			this.EndMorph();
			BattleUiRoleData curRoleData = ModelBase<BattleUiModel>.Instance.GetCurRoleData();
			if (curRoleData == null)
			{
				return;
			}
			BattleUiRoleData battleUiRoleData = curRoleData;
			int? num = (battleUiRoleData.RoleConfig != null) ? new int?(battleUiRoleData.RoleConfig.GetValueOrDefault().Id) : null;
			if (num == null)
			{
				return;
			}
			Func<RoleMorphHandleBase> func;
			if (this.HandleMap.TryGetValue(num.Value, out func))
			{
				this.CurMorphHandle = func();
				this.CurMorphHandle.BeginMorph();
			}
		}

		// Token: 0x060355F7 RID: 218615 RVA: 0x00D63313 File Offset: 0x00D61513
		public void EndMorph()
		{
			if (this.CurMorphHandle != null)
			{
				this.CurMorphHandle.EndMorph();
				this.CurMorphHandle = null;
			}
		}

		// Token: 0x060355F8 RID: 218616 RVA: 0x00D63330 File Offset: 0x00D61530
		public RoleMorphController()
		{
			Dictionary<int, Func<RoleMorphHandleBase>> dictionary = new Dictionary<int, Func<RoleMorphHandleBase>>();
			dictionary.Add(5012, () => new RoleMorphPaoTaiHandle());
			dictionary.Add(5020, () => new RoleMorphLiuLiDaoLingHandle());
			dictionary.Add(5021, () => new RoleMorphGuYingXiongKaiHandle());
			this.HandleMap = dictionary;
			base..ctor();
		}

		// Token: 0x0401EAA9 RID: 125609
		private readonly Dictionary<int, Func<RoleMorphHandleBase>> HandleMap;

		// Token: 0x0401EAAA RID: 125610
		[Nullable(2)]
		private RoleMorphHandleBase CurMorphHandle;
	}
}
