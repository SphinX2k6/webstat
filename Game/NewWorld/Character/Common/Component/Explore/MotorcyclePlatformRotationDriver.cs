using System;
using System.Runtime.CompilerServices;
using CSharpScript.Game.Camera;
using CSharpScript.Game.NewWorld.Character.Custom.Components;

namespace CSharpScript.Game.NewWorld.Character.Common.Component.Explore
{
	// Token: 0x0200495E RID: 18782
	[NullableContext(1)]
	[Nullable(0)]
	public class MotorcyclePlatformRotationDriver : IClear
	{
		// Token: 0x060311DF RID: 201183 RVA: 0x00C39C30 File Offset: 0x00C37E30
		public bool Begin(MotorcycleExploreComponent exploreComp, GrapplingHookPointComponent hook)
		{
			this.End();
			BaseActorComponent component = hook.Entity.GetComponent<BaseActorComponent>();
			BaseActorComponent actorComponent = exploreComp.ActorComponent;
			if (component == null || actorComponent == null)
			{
				Log instance = Singleton<Log>.Instance;
				ELogModule module = ELogModule.Vehicle;
				ELogAuthor author = ELogAuthor.WRY;
				string log_CONTEXT = MotorcyclePlatformRotationDriver.LOG_CONTEXT;
				ValueTuple<string, object> valueTuple = new ValueTuple<string, object>("reason", "初始化所需的关键引用缺失");
				instance.Warn(module, author, log_CONTEXT, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple));
				return false;
			}
			this.PlatformActorComp = component;
			this.MotorActorComp = actorComponent;
			this.PlatformYawInterpSpeed = hook.GetMotorEjectHookInterpSpeed();
			this.CaptureMotorAnchor();
			this.IsActive = true;
			Log instance2 = Singleton<Log>.Instance;
			ELogModule module2 = ELogModule.Vehicle;
			ELogAuthor author2 = ELogAuthor.WRY;
			string message = "[摩托弹射钩锁启动跟随相机]";
			ValueTuple<string, object> valueTuple2 = new ValueTuple<string, object>("InterpSpeed", this.PlatformYawInterpSpeed);
			instance2.Info(module2, author2, message, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple2));
			return true;
		}

		// Token: 0x060311E0 RID: 201184 RVA: 0x00C39CE8 File Offset: 0x00C37EE8
		private void CaptureMotorAnchor()
		{
			if (this.PlatformActorComp == null || this.MotorActorComp == null)
			{
				return;
			}
			Rotator actorRotationProxy = this.PlatformActorComp.ActorRotationProxy;
			Vector actorLocationProxy = this.PlatformActorComp.ActorLocationProxy;
			Rotator actorRotationProxy2 = this.MotorActorComp.ActorRotationProxy;
			Vector actorLocationProxy2 = this.MotorActorComp.ActorLocationProxy;
			this.InitialMotorYawOffset = Rotator.NormalizeAxis(actorRotationProxy2.Yaw - actorRotationProxy.Yaw);
			double num = actorLocationProxy2.X - actorLocationProxy.X;
			double num2 = actorLocationProxy2.Y - actorLocationProxy.Y;
			float num3 = actorRotationProxy.Yaw * 0.017453292f;
			double num4 = Math.Cos((double)num3);
			double num5 = Math.Sin((double)num3);
			this.MotorLocalX = num * num4 + num2 * num5;
			this.MotorLocalY = -num * num5 + num2 * num4;
			this.InitialMotorPitch = actorRotationProxy2.Pitch;
			this.InitialMotorRoll = actorRotationProxy2.Roll;
		}

		// Token: 0x060311E1 RID: 201185 RVA: 0x00C39DC0 File Offset: 0x00C37FC0
		public void Tick(float deltaMs)
		{
			if (!this.IsActive)
			{
				return;
			}
			if (this.PlatformActorComp == null || this.MotorActorComp == null)
			{
				return;
			}
			ControllerBase<CameraController>.Instance.GetCameraRotation(this.TmpRotator, "MainCamera");
			float yaw = this.TmpRotator.Yaw;
			float yaw2 = this.PlatformActorComp.ActorRotationProxy.Yaw;
			float targetYaw = Rotator.NormalizeAxis(yaw - this.InitialMotorYawOffset);
			float num = this.RInterpYawTo(yaw2, targetYaw, deltaMs);
			Rotator actorRotationProxy = this.PlatformActorComp.ActorRotationProxy;
			this.TmpRotator.Pitch = actorRotationProxy.Pitch;
			this.TmpRotator.Yaw = num;
			this.TmpRotator.Roll = actorRotationProxy.Roll;
			this.PlatformActorComp.SetActorRotation(this.TmpRotator.ToUeRotator(), MotorcyclePlatformRotationDriver.LOG_CONTEXT, false);
			this.SyncMotorToPlatform(num);
		}

		// Token: 0x060311E2 RID: 201186 RVA: 0x00C39E90 File Offset: 0x00C38090
		private float RInterpYawTo(float currentYaw, float targetYaw, float deltaMs)
		{
			float num = Rotator.NormalizeAxis(targetYaw - currentYaw);
			if (Math.Abs(num) < 0.01f)
			{
				return targetYaw;
			}
			float num2 = deltaMs / (float)Singleton<TimeUtil>.Instance.InverseMillisecond;
			double num3 = 1.0 - Math.Exp((double)(-(double)this.PlatformYawInterpSpeed * num2));
			return Rotator.NormalizeAxis((float)((double)currentYaw + (double)num * num3));
		}

		// Token: 0x060311E3 RID: 201187 RVA: 0x00C39EEC File Offset: 0x00C380EC
		private void SyncMotorToPlatform(float platformYaw)
		{
			if (this.PlatformActorComp == null || this.MotorActorComp == null)
			{
				return;
			}
			Vector actorLocationProxy = this.PlatformActorComp.ActorLocationProxy;
			Vector actorLocationProxy2 = this.MotorActorComp.ActorLocationProxy;
			float yaw = Rotator.NormalizeAxis(platformYaw + this.InitialMotorYawOffset);
			float num = platformYaw * 0.017453292f;
			double num2 = Math.Cos((double)num);
			double num3 = Math.Sin((double)num);
			double inX = actorLocationProxy.X + this.MotorLocalX * num2 - this.MotorLocalY * num3;
			double inY = actorLocationProxy.Y + this.MotorLocalX * num3 + this.MotorLocalY * num2;
			this.TmpVector.Set(inX, inY, actorLocationProxy2.Z);
			this.TmpRotator.Pitch = this.InitialMotorPitch;
			this.TmpRotator.Yaw = yaw;
			this.TmpRotator.Roll = this.InitialMotorRoll;
			this.MotorActorComp.SetActorLocationAndRotation(this.TmpVector.ToUeVector(false), this.TmpRotator.ToUeRotator(), MotorcyclePlatformRotationDriver.LOG_CONTEXT, false, null);
		}

		// Token: 0x060311E4 RID: 201188 RVA: 0x00C39FEE File Offset: 0x00C381EE
		public void End()
		{
			this.IsActive = false;
			this.PlatformActorComp = null;
			this.MotorActorComp = null;
		}

		// Token: 0x060311E5 RID: 201189 RVA: 0x00C3A005 File Offset: 0x00C38205
		public bool ClearObject()
		{
			this.End();
			return true;
		}

		// Token: 0x0401C472 RID: 115826
		private static readonly string LOG_CONTEXT = "MotorcyclePlatformRotationDriver";

		// Token: 0x0401C473 RID: 115827
		private const float PLATFORM_YAW_ALIGNED_EPSILON = 0.01f;

		// Token: 0x0401C474 RID: 115828
		private bool IsActive;

		// Token: 0x0401C475 RID: 115829
		[Nullable(2)]
		private BaseActorComponent PlatformActorComp;

		// Token: 0x0401C476 RID: 115830
		[Nullable(2)]
		private BaseActorComponent MotorActorComp;

		// Token: 0x0401C477 RID: 115831
		private float InitialMotorYawOffset;

		// Token: 0x0401C478 RID: 115832
		private double MotorLocalX;

		// Token: 0x0401C479 RID: 115833
		private double MotorLocalY;

		// Token: 0x0401C47A RID: 115834
		private float InitialMotorPitch;

		// Token: 0x0401C47B RID: 115835
		private float InitialMotorRoll;

		// Token: 0x0401C47C RID: 115836
		private float PlatformYawInterpSpeed;

		// Token: 0x0401C47D RID: 115837
		private readonly Vector TmpVector = Vector.Create();

		// Token: 0x0401C47E RID: 115838
		private readonly Rotator TmpRotator = Rotator.Create();
	}
}
