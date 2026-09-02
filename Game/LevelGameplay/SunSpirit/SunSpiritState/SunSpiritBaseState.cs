using System;
using System.Reflection;
using System.Runtime.CompilerServices;

namespace CSharpScript.Game.LevelGamePlay.SunSpirit.SunSpiritState
{
	// Token: 0x02006AA7 RID: 27303
	[NullableContext(1)]
	[Nullable(0)]
	public class SunSpiritBaseState
	{
		// Token: 0x0604384D RID: 276557 RVA: 0x011679B9 File Offset: 0x01165BB9
		protected SunSpiritBaseState(ESunSpiritStateType stateTypeInternal, SunSpiritData sunSpiritData)
		{
			this.StateTypeInternal = stateTypeInternal;
			this.SunSpiritData = sunSpiritData;
			this.NeedTickInternal = this.HasTickFunc();
		}

		// Token: 0x1700A279 RID: 41593
		// (get) Token: 0x0604384E RID: 276558 RVA: 0x011679DB File Offset: 0x01165BDB
		public ESunSpiritStateType StateType
		{
			get
			{
				return this.StateTypeInternal;
			}
		}

		// Token: 0x0604384F RID: 276559 RVA: 0x011679E3 File Offset: 0x01165BE3
		public bool Enter()
		{
			if ((this.Status & ESunSpiritStateStatus.Entering) != ESunSpiritStateStatus.None)
			{
				return false;
			}
			this.Status |= ESunSpiritStateStatus.Entering;
			bool result = this.OnEnter();
			this.Status |= ESunSpiritStateStatus.Entered;
			return result;
		}

		// Token: 0x06043850 RID: 276560 RVA: 0x01167A13 File Offset: 0x01165C13
		protected virtual bool OnEnter()
		{
			return true;
		}

		// Token: 0x06043851 RID: 276561 RVA: 0x01167A16 File Offset: 0x01165C16
		public void Exit()
		{
			if ((this.Status & ESunSpiritStateStatus.Exiting) != ESunSpiritStateStatus.None)
			{
				return;
			}
			this.Status |= ESunSpiritStateStatus.Exiting;
			this.OnExit();
			this.Status |= ESunSpiritStateStatus.Exited;
		}

		// Token: 0x06043852 RID: 276562 RVA: 0x01167A45 File Offset: 0x01165C45
		protected virtual void OnExit()
		{
		}

		// Token: 0x06043853 RID: 276563 RVA: 0x01167A47 File Offset: 0x01165C47
		public void Tick(float deltaSeconds)
		{
			if (!this.IsTickable())
			{
				return;
			}
			this.OnTick(deltaSeconds);
		}

		// Token: 0x06043854 RID: 276564 RVA: 0x01167A59 File Offset: 0x01165C59
		protected virtual void OnTick(float deltaSeconds)
		{
		}

		// Token: 0x06043855 RID: 276565 RVA: 0x01167A5B File Offset: 0x01165C5B
		public virtual bool IsSameState(SunSpiritBaseState otherState)
		{
			return this.StateType == otherState.StateType && otherState.GetType() == base.GetType();
		}

		// Token: 0x06043856 RID: 276566 RVA: 0x01167A7E File Offset: 0x01165C7E
		public bool IsTickable()
		{
			return (this.Status & ESunSpiritStateStatus.Entered) != ESunSpiritStateStatus.None && (this.Status & ESunSpiritStateStatus.Exited) == ESunSpiritStateStatus.None && this.NeedTickInternal;
		}

		// Token: 0x06043857 RID: 276567 RVA: 0x01167A9C File Offset: 0x01165C9C
		private bool HasTickFunc()
		{
			MethodInfo method = base.GetType().GetMethod("OnTick", BindingFlags.Instance | BindingFlags.NonPublic);
			return ((method != null) ? method.DeclaringType : null) != typeof(SunSpiritBaseState);
		}

		// Token: 0x04025B85 RID: 154501
		protected ESunSpiritStateType StateTypeInternal;

		// Token: 0x04025B86 RID: 154502
		protected SunSpiritData SunSpiritData;

		// Token: 0x04025B87 RID: 154503
		private ESunSpiritStateStatus Status;

		// Token: 0x04025B88 RID: 154504
		public bool IsFinished;

		// Token: 0x04025B89 RID: 154505
		private bool NeedTickInternal;
	}
}
