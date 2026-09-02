using System;
using System.Runtime.CompilerServices;
using Aki.TDConfigMgr.Component;
using CSharpScript.Game.Module.WuwaGo.Model.Role;
using Cysharp.Threading.Tasks;
using UnrealEngine;

namespace CSharpScript.Game.Module.WuwaGo.Controller.Role
{
	// Token: 0x02004AFA RID: 19194
	[NullableContext(1)]
	[Nullable(0)]
	public abstract class WuWaGoRoleController : ExecutableUnitBase, IStaticVariableResetter
	{
		// Token: 0x060320E1 RID: 205025 RVA: 0x00C86875 File Offset: 0x00C84A75
		static WuWaGoRoleController()
		{
			StaticVariableRegister.RegisterAndExecute(new Action(WuWaGoRoleController.CreateStaticDefaultValue), new Action(WuWaGoRoleController.ResetStaticDefaultValue));
		}

		// Token: 0x060320E2 RID: 205026 RVA: 0x00C86894 File Offset: 0x00C84A94
		public static void CreateStaticDefaultValue()
		{
			WuWaGoRoleController.ForwardAlignThresholdSquared = Math.Pow(Math.Cos(0.7853981633974483), 2.0);
		}

		// Token: 0x060320E3 RID: 205027 RVA: 0x00C868B7 File Offset: 0x00C84AB7
		public static void ResetStaticDefaultValue()
		{
			WuWaGoRoleController.ForwardAlignThresholdSquared = Math.Pow(Math.Cos(0.7853981633974483), 2.0);
		}

		// Token: 0x1700856D RID: 34157
		// (get) Token: 0x060320E4 RID: 205028
		public abstract WuWaGoRole BaseRole { get; }

		// Token: 0x1700856E RID: 34158
		// (get) Token: 0x060320E5 RID: 205029
		public abstract EWuWaGoRoleType RoleType { get; }

		// Token: 0x060320E6 RID: 205030
		[NullableContext(2)]
		public abstract UniTask TakeAttack(bool playBeHitAnim, UAnimMontage deathMontage = null);

		// Token: 0x060320E7 RID: 205031
		public abstract void SyncRuntimePresentationAfterCoordinateChanged();

		// Token: 0x060320E8 RID: 205032
		public abstract void HideAttackRangeEffect(string reason);

		// Token: 0x060320E9 RID: 205033
		public abstract void ShowAttackRangeEffect(string reason);

		// Token: 0x060320EA RID: 205034 RVA: 0x00C868DA File Offset: 0x00C84ADA
		public virtual void OnPlayIntroBegin()
		{
		}

		// Token: 0x060320EB RID: 205035 RVA: 0x00C868DC File Offset: 0x00C84ADC
		public virtual void OnEnterRunning()
		{
		}

		// Token: 0x0401D442 RID: 119874
		private const int FORWARD_ANGLE_LIMIT_DEG = 45;

		// Token: 0x0401D443 RID: 119875
		protected static double ForwardAlignThresholdSquared;
	}
}
