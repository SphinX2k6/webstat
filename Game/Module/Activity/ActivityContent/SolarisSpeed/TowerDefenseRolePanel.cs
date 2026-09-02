using System;
using System.Runtime.CompilerServices;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.CompilerServices;

namespace CSharpScript.Game.Module.Activity.ActivityContent.SolarisSpeed
{
	// Token: 0x0200639A RID: 25498
	[NullableContext(1)]
	[Nullable(0)]
	public class TowerDefenseRolePanel : SolarSpeedRolePanelBase
	{
		// Token: 0x06040053 RID: 262227 RVA: 0x01068C3C File Offset: 0x01066E3C
		private UniTask InitDescContent()
		{
			TowerDefenseRolePanel.<InitDescContent>d__1 <InitDescContent>d__;
			<InitDescContent>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<InitDescContent>d__.<>4__this = this;
			<InitDescContent>d__.<>1__state = -1;
			<InitDescContent>d__.<>t__builder.Start<TowerDefenseRolePanel.<InitDescContent>d__1>(ref <InitDescContent>d__);
			return <InitDescContent>d__.<>t__builder.Task;
		}

		// Token: 0x06040054 RID: 262228 RVA: 0x01068C80 File Offset: 0x01066E80
		protected override UniTask OnBeforeStartAsync()
		{
			TowerDefenseRolePanel.<OnBeforeStartAsync>d__2 <OnBeforeStartAsync>d__;
			<OnBeforeStartAsync>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<OnBeforeStartAsync>d__.<>4__this = this;
			<OnBeforeStartAsync>d__.<>1__state = -1;
			<OnBeforeStartAsync>d__.<>t__builder.Start<TowerDefenseRolePanel.<OnBeforeStartAsync>d__2>(ref <OnBeforeStartAsync>d__);
			return <OnBeforeStartAsync>d__.<>t__builder.Task;
		}

		// Token: 0x06040055 RID: 262229 RVA: 0x01068CC3 File Offset: 0x01066EC3
		protected override void OnRefresh(ISolarSpeedRolePanelData data)
		{
			this.DescContent.Refresh((ITowerDefenseRolePanelData)data);
		}

		// Token: 0x04023F29 RID: 147241
		private TowerDefenseRoleDescContent DescContent;
	}
}
