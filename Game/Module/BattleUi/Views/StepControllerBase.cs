using System;
using System.Runtime.CompilerServices;
using CSharpScript.Game.Ui;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.CompilerServices;

namespace CSharpScript.Game.Module.BattleUi.Views
{
	// Token: 0x02006073 RID: 24691
	[NullableContext(2)]
	[Nullable(0)]
	public abstract class StepControllerBase : UiPanelBase
	{
		// Token: 0x17009ACE RID: 39630
		// (get) Token: 0x0603E43B RID: 255035
		public abstract bool Enable { get; }

		// Token: 0x0603E43C RID: 255036 RVA: 0x00FE56BB File Offset: 0x00FE38BB
		public virtual bool CheckTextVisible()
		{
			return true;
		}

		// Token: 0x0603E43D RID: 255037 RVA: 0x00FE56BE File Offset: 0x00FE38BE
		public virtual void OnTick(float delta)
		{
		}

		// Token: 0x0603E43E RID: 255038 RVA: 0x00FE56C0 File Offset: 0x00FE38C0
		public virtual UniTask OnConfigRefresh(IMissionItemViewShowData showData, MissionViewStepTextInfoBase config)
		{
			StepControllerBase.<OnConfigRefresh>d__6 <OnConfigRefresh>d__;
			<OnConfigRefresh>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<OnConfigRefresh>d__.<>4__this = this;
			<OnConfigRefresh>d__.showData = showData;
			<OnConfigRefresh>d__.config = config;
			<OnConfigRefresh>d__.<>1__state = -1;
			<OnConfigRefresh>d__.<>t__builder.Start<StepControllerBase.<OnConfigRefresh>d__6>(ref <OnConfigRefresh>d__);
			return <OnConfigRefresh>d__.<>t__builder.Task;
		}

		// Token: 0x04022E70 RID: 142960
		protected IMissionItemViewShowData ShowData;

		// Token: 0x04022E71 RID: 142961
		protected MissionViewStepTextInfoBase Config;
	}
}
