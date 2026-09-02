using System;
using System.Runtime.CompilerServices;

namespace CSharpScript.Game.Ui
{
	// Token: 0x020049AB RID: 18859
	[NullableContext(1)]
	[Nullable(new byte[]
	{
		0,
		1
	})]
	public abstract class UiControllerBase<T> : ControllerBase<T> where T : class, new()
	{
		// Token: 0x060313D2 RID: 201682 RVA: 0x00C42AE1 File Offset: 0x00C40CE1
		public override bool Init()
		{
			bool result = base.Init();
			this.OnRegisterNetEvent();
			this.OnAddEvents();
			this.OnAddOpenViewCheckFunction();
			return result;
		}

		// Token: 0x060313D3 RID: 201683 RVA: 0x00C42AFB File Offset: 0x00C40CFB
		public override bool Clear()
		{
			this.OnUnRegisterNetEvent();
			this.OnRemoveEvents();
			this.OnRemoveOpenViewCheckFunction();
			return base.Clear();
		}

		// Token: 0x060313D4 RID: 201684 RVA: 0x00C42B15 File Offset: 0x00C40D15
		protected virtual void OnRegisterNetEvent()
		{
		}

		// Token: 0x060313D5 RID: 201685 RVA: 0x00C42B17 File Offset: 0x00C40D17
		protected virtual void OnUnRegisterNetEvent()
		{
		}

		// Token: 0x060313D6 RID: 201686 RVA: 0x00C42B19 File Offset: 0x00C40D19
		protected virtual void OnAddEvents()
		{
		}

		// Token: 0x060313D7 RID: 201687 RVA: 0x00C42B1B File Offset: 0x00C40D1B
		protected virtual void OnRemoveEvents()
		{
		}

		// Token: 0x060313D8 RID: 201688 RVA: 0x00C42B1D File Offset: 0x00C40D1D
		protected virtual void OnAddOpenViewCheckFunction()
		{
		}

		// Token: 0x060313D9 RID: 201689 RVA: 0x00C42B1F File Offset: 0x00C40D1F
		protected virtual void OnRemoveOpenViewCheckFunction()
		{
		}
	}
}
