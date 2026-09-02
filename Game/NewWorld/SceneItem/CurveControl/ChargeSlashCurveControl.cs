using System;
using System.Runtime.CompilerServices;
using Aki.TDConfigMgr.Component;
using CSharpScript.Game.NewWorld.Common.Component;
using UnrealEngine;

namespace CSharpScript.Game.NewWorld.SceneItem.CurveControl
{
	// Token: 0x02004871 RID: 18545
	[NullableContext(2)]
	[Nullable(0)]
	public class ChargeSlashCurveControl : CurveControlBase
	{
		// Token: 0x06030429 RID: 197673 RVA: 0x00BBD630 File Offset: 0x00BBB830
		[NullableContext(1)]
		protected override void OnInit(CurveControlComponent config)
		{
			Entity entity = this.Entity;
			this.ActorComp = ((entity != null) ? entity.GetComponent<SceneItemActorComponent>() : null);
			Entity entity2 = this.Entity;
			this.TagComp = ((entity2 != null) ? entity2.GetComponent<LevelTagComponent>() : null);
			IChargeSlashControl chargeSlashConfig = config.CurveControlConfig;
			if (chargeSlashConfig != null)
			{
				this.RiseHeight = (float)chargeSlashConfig.UpHeight;
				if (!string.IsNullOrEmpty(chargeSlashConfig.UpCurvePath))
				{
					Singleton<ResourceSystem>.Instance.LoadAsync<UCurveFloat>(chargeSlashConfig.UpCurvePath, delegate([Nullable(2)] UCurveFloat obj, string _)
					{
						if (obj != null)
						{
							this.RiseCurve = obj;
							return;
						}
						Log instance = Singleton<Log>.Instance;
						ELogModule module = ELogModule.SceneItemCurveControl;
						ELogAuthor author = ELogAuthor.CH;
						string message = "[ChargeSlashCurveControl.OnInit] RiseCurve Load Failed";
						ValueTuple<string, object> valueTuple = new ValueTuple<string, object>("Path", chargeSlashConfig.UpCurvePath);
						instance.Error(module, author, message, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple));
					}, 100, "js_undefined");
				}
			}
		}

		// Token: 0x0603042A RID: 197674 RVA: 0x00BBD6DB File Offset: 0x00BBB8DB
		protected override void OnStart()
		{
			this.StartLoc.DeepCopy(this.ActorComp.ActorLocationProxy);
			this.StartRaiseMaterial = false;
			this.StopRaiseMaterial = false;
			this.StartRebornMaterial = false;
		}

		// Token: 0x0603042B RID: 197675 RVA: 0x00BBD708 File Offset: 0x00BBB908
		protected override void TickStartStage()
		{
			if (this.RiseCurve == null)
			{
				Log instance = Singleton<Log>.Instance;
				ELogModule module = ELogModule.SceneItemCurveControl;
				ELogAuthor author = ELogAuthor.CH;
				string message = "[ChargeSlashCurveControl.TickStartStage] RiseCurve is null";
				string item = "PbDataId";
				SceneItemActorComponent actorComp = this.ActorComp;
				ValueTuple<string, object> valueTuple = new ValueTuple<string, object>(item, (actorComp != null) ? new int?(actorComp.CreatureData.GetPbDataId()) : null);
				instance.Error(module, author, message, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple));
				return;
			}
			if (!this.StartRaiseMaterial)
			{
				this.StartRaiseMaterial = true;
				LevelTagComponent tagComp = this.TagComp;
				if (tagComp != null && tagComp.HasTag(CurveControlDefine.RebornPerformanceTagId))
				{
					LevelTagComponent tagComp2 = this.TagComp;
					if (tagComp2 != null)
					{
						tagComp2.RemoveTag(new int?(CurveControlDefine.RebornPerformanceTagId));
					}
				}
				LevelTagComponent tagComp3 = this.TagComp;
				if (tagComp3 != null)
				{
					tagComp3.AddTag(new int?(CurveControlDefine.RaisePerformanceTagId));
				}
			}
			float inTime = this.CurTime / this.StartTime;
			float floatValue = this.RiseCurve.GetFloatValue(inTime);
			Vector vector = Vector.Create();
			vector.DeepCopy(this.StartLoc);
			vector.Z += (double)(floatValue * this.RiseHeight);
			this.ActorComp.SetActorLocation(vector.ToUeVector(false), "ChargeSlashCurveControl.StartStage", true);
		}

		// Token: 0x0603042C RID: 197676 RVA: 0x00BBD82C File Offset: 0x00BBBA2C
		protected override void TickEndStage()
		{
			if (this.CurTime <= this.StartTime + this.LoopTime || this.StopRaiseMaterial)
			{
				if (this.CurTime > this.StartTime + this.LoopTime + 800f && !this.StartRebornMaterial)
				{
					this.StartRebornMaterial = true;
					SceneItemActorComponent actorComp = this.ActorComp;
					if (actorComp != null)
					{
						actorComp.SetActorLocation(this.StartLoc.ToUeVector(false), "ChargeSlashCurveControl.EndStage", true);
					}
					LevelTagComponent tagComp = this.TagComp;
					if (tagComp == null)
					{
						return;
					}
					tagComp.AddTag(new int?(CurveControlDefine.RebornPerformanceTagId));
				}
				return;
			}
			this.StopRaiseMaterial = true;
			LevelTagComponent tagComp2 = this.TagComp;
			if (tagComp2 == null)
			{
				return;
			}
			tagComp2.RemoveTag(new int?(CurveControlDefine.RaisePerformanceTagId));
		}

		// Token: 0x0401BB71 RID: 113521
		private SceneItemActorComponent ActorComp;

		// Token: 0x0401BB72 RID: 113522
		private LevelTagComponent TagComp;

		// Token: 0x0401BB73 RID: 113523
		[Nullable(1)]
		private readonly Vector StartLoc = Vector.Create();

		// Token: 0x0401BB74 RID: 113524
		private float RiseHeight;

		// Token: 0x0401BB75 RID: 113525
		private UCurveFloat RiseCurve;

		// Token: 0x0401BB76 RID: 113526
		private bool StartRaiseMaterial;

		// Token: 0x0401BB77 RID: 113527
		private bool StopRaiseMaterial;

		// Token: 0x0401BB78 RID: 113528
		private bool StartRebornMaterial;
	}
}
