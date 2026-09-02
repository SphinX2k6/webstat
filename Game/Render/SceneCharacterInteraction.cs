using System;
using System.Runtime.CompilerServices;
using AkiClient.Game.Aki.Render.RuntimeBP.Interaction;
using CSharpScript.Core.Common;
using CSharpScript.Game.Utils;
using UnrealEngine;

namespace CSharpScript.Game.Render
{
	// Token: 0x02004782 RID: 18306
	[NullableContext(2)]
	[Nullable(0)]
	public class SceneCharacterInteraction : IStaticVariableResetter
	{
		// Token: 0x0602F7E8 RID: 194536 RVA: 0x00B4BC37 File Offset: 0x00B49E37
		static SceneCharacterInteraction()
		{
			StaticVariableRegister.RegisterAndExecute(new Action(SceneCharacterInteraction.CreateStaticDefaultValue), new Action(SceneCharacterInteraction.ResetStaticDefaultValue));
		}

		// Token: 0x0602F7E9 RID: 194537 RVA: 0x00B4BC6B File Offset: 0x00B49E6B
		public void SetInWater()
		{
			this.IsInWaterOrOnMaterial = true;
			this.PhysicalMaterial = null;
		}

		// Token: 0x0602F7EA RID: 194538 RVA: 0x00B4BC7B File Offset: 0x00B49E7B
		[NullableContext(1)]
		public void SetOnMaterial(UPhysicalMaterial physicalMaterial)
		{
			this.IsInWaterOrOnMaterial = true;
			this.PhysicalMaterial = physicalMaterial;
		}

		// Token: 0x0602F7EB RID: 194539 RVA: 0x00B4BC8B File Offset: 0x00B49E8B
		public bool GetInWater()
		{
			return this.IsInWaterOrOnMaterial && this.PhysicalMaterial == null;
		}

		// Token: 0x0602F7EC RID: 194540 RVA: 0x00B4BCA0 File Offset: 0x00B49EA0
		public bool GetInAudioShr()
		{
			return this.IsInAudioShr;
		}

		// Token: 0x0602F7ED RID: 194541 RVA: 0x00B4BCA8 File Offset: 0x00B49EA8
		public FName GetAudioShrTag()
		{
			return this.AudioShrTag.Value;
		}

		// Token: 0x0602F7EE RID: 194542 RVA: 0x00B4BCB5 File Offset: 0x00B49EB5
		public double GetWaterHitLocationZ()
		{
			if (!(this.EnviInteractionData != null))
			{
				return double.NegativeInfinity;
			}
			return (double)this.EnviInteractionData.HitWaterLocation.Z;
		}

		// Token: 0x0602F7EF RID: 194543 RVA: 0x00B4BCE0 File Offset: 0x00B49EE0
		public double GetWaterHeight()
		{
			return this.WaterHeight;
		}

		// Token: 0x0602F7F0 RID: 194544 RVA: 0x00B4BCE8 File Offset: 0x00B49EE8
		public double GetWaterDepth()
		{
			if (this.UseCppCheck)
			{
				return (double)((this.EnviInteractionData != null) ? this.EnviInteractionData.WaterDepth : 0f);
			}
			return this.WaterHeight - (this.TsActorLocation.Z - this.CapsuleHalfHeight);
		}

		// Token: 0x0602F7F1 RID: 194545 RVA: 0x00B4BD38 File Offset: 0x00B49F38
		[NullableContext(1)]
		public void Start(TsBaseCharacter owner, PDA_InteractionPlayerConfig_C config, float updateInternalScale = 1f)
		{
			this.OwnerCharacter = owner;
			this.UpdateWaterStateInternalScale = updateInternalScale;
			if (config != null)
			{
				this.Config = config;
				this.Init();
				this.Enable();
				return;
			}
			Log instance = Singleton<Log>.Instance;
			ELogModule module = ELogModule.Render;
			ELogAuthor author = ELogAuthor.LSY;
			string message = ": 创建了没有配置的交互控制";
			ValueTuple<string, object> valueTuple = new ValueTuple<string, object>("Actor", this.OwnerCharacter);
			instance.Error(module, author, message, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple));
		}

		// Token: 0x170081AC RID: 33196
		// (get) Token: 0x0602F7F2 RID: 194546 RVA: 0x00B4BD98 File Offset: 0x00B49F98
		// (set) Token: 0x0602F7F3 RID: 194547 RVA: 0x00B4BDA0 File Offset: 0x00B49FA0
		private protected Vector TempVector { protected get; private set; }

		// Token: 0x0602F7F4 RID: 194548 RVA: 0x00B4BDAC File Offset: 0x00B49FAC
		[NullableContext(1)]
		private FName FindAudioShrubTagFromComp(UStaticMesh staticMesh)
		{
			for (int i = 0; i < staticMesh.Tags.Num(); i++)
			{
				string text = staticMesh.Tags.Get(i).ToString();
				if (text.StartsWith("Audio_", StringComparison.Ordinal))
				{
					return new FName(text.Substring("Audio_".Length));
				}
			}
			return FNameUtil.NONE;
		}

		// Token: 0x0602F7F5 RID: 194549 RVA: 0x00B4BE14 File Offset: 0x00B4A014
		public void Update(float deltaSeconds)
		{
			if (!this.IsEnable)
			{
				return;
			}
			this.UseCppCheck = (UKismetSystemLibrary.GetConsoleVariableFloatValue("r.Kuro.InteractionEffect.UseCppWaterEffect") > 0f);
			if (this.UseCppCheck)
			{
				UKuroEnviInteractionComponent enviInteractionComponent = this.EnviInteractionComponent;
				this.EnviInteractionData = ((enviInteractionComponent != null) ? enviInteractionComponent.GetEnviInteractionData() : null);
			}
			if (this.OwnerCharacter != null && UKismetSystemLibrary.IsValid(this.OwnerCharacter))
			{
				this.ActorLocation = new FVectorDouble?(this.OwnerCharacter.D_K2_GetActorLocation());
				Vector tsPreviousActorLocation = this.TsPreviousActorLocation;
				if (tsPreviousActorLocation != null)
				{
					tsPreviousActorLocation.DeepCopy(this.TsActorLocation);
				}
				Vector tsActorLocation = this.TsActorLocation;
				if (tsActorLocation != null)
				{
					FVectorDouble value = this.ActorLocation.Value;
					tsActorLocation.FromUeVector(value);
				}
				Vector tsActorLocation2 = this.TsActorLocation;
				if (tsActorLocation2 != null)
				{
					tsActorLocation2.Subtraction(this.TsPreviousActorLocation, this.TempVector);
				}
				Vector tempVector = this.TempVector;
				if (tempVector != null)
				{
					tempVector.Division((double)deltaSeconds, this.ActorSpeed);
				}
				bool flag = true;
				this.UpdateWaterStateCounter -= deltaSeconds;
				if (this.UpdateWaterStateCounter > 0f)
				{
					flag = false;
				}
				else
				{
					this.UpdateWaterStateCounter = this.UpdateWaterStateInternal;
				}
				if (this.UseCppCheck)
				{
					flag = true;
				}
				if (this.WaterEffect != null)
				{
					if (flag)
					{
						this.CheckInWater(deltaSeconds);
						double num = this.TsActorLocation.Z - this.CapsuleHalfHeight;
						if (this.EnviInteractionData != null)
						{
							this.WaterEffect.SetWaterDataEnviDataCheckFly(this.EnviInteractionData, this.TsActorLocation, this.ActorSpeed);
						}
						if (this.IsInWaterOrOnMaterial)
						{
							if (this.PhysicalMaterial == null)
							{
								if (this.UseCppCheck)
								{
									this.WaterEffect.SetStateInWaterEnviData(this.EnviInteractionData, this.ActorSpeed, this.TsActorLocation);
								}
								else
								{
									this.WaterEffect.SetStateInWater(this.WaterHeight - num, this.WaterNormal, this.ActorSpeed, this.TsActorLocation, this.WaterHeight);
								}
							}
							else if (this.UseCppCheck)
							{
								this.WaterEffect.SetStateOnMaterialEnviData(this.PhysicalMaterial, this.ActorSpeed, this.TsActorLocation, this.EnviInteractionData);
							}
							else
							{
								this.WaterEffect.SetStateOnMaterial(this.PhysicalMaterial, this.WaterHeight - num, this.WaterNormal, this.ActorSpeed, this.TsActorLocation, this.WaterHeight);
							}
						}
						else
						{
							this.WaterEffect.SetStateNone(this.ActorSpeed);
						}
					}
					this.WaterEffect.Tick();
				}
				if (this.TriggerEffect != null && this.EnviInteractionData != null)
				{
					this.TriggerEffect.Data = this.EnviInteractionData;
					this.TriggerEffect.Tick();
				}
				if (this.FoliageEffect != null)
				{
					this.FoliageEffect.Tick(deltaSeconds);
				}
				this.IsInAudioShr = false;
				this.AudioShrTag = new FName?(FNameUtil.NONE);
				if (this.EnviInteractionData != null && this.EnviInteractionData.bHitAudioShrub && this.EnviInteractionData.AudioShrubStaticMeshComp != null && this.EnviInteractionData.AudioShrubStaticMeshComp.GetCollisionProfileName().Equals(SceneCharacterInteraction.NoCollisionProfileName))
				{
					this.IsInAudioShr = true;
					UStaticMesh staticMesh = this.EnviInteractionData.AudioShrubStaticMeshComp.StaticMesh;
					this.AudioShrTag = new FName?((staticMesh != null) ? this.FindAudioShrubTagFromComp(staticMesh) : FNameUtil.NONE);
				}
			}
		}

		// Token: 0x0602F7F6 RID: 194550 RVA: 0x00B4C150 File Offset: 0x00B4A350
		public void Init()
		{
			TsBaseCharacter ownerCharacter = this.OwnerCharacter;
			if (((ownerCharacter != null) ? ownerCharacter.CapsuleComponent : null) != null)
			{
				this.CapsuleHalfHeight = (double)this.OwnerCharacter.CapsuleComponent.CapsuleHalfHeight;
				this.WaterEffect = new SceneCharacterWaterEffect();
				this.WaterEffect.Config = this.Config.水特效;
				this.WaterEffect.Start(this.OwnerCharacter);
				this.WaterEffect.Enable();
				if (!Singleton<Info>.Instance.IsMobilePlatform())
				{
					this.TriggerEffect = new SceneCharacterTriggerEffect();
					this.TriggerEffect.Start(this.OwnerCharacter);
					this.TriggerEffect.Enable();
					this.FoliageEffect = new SceneCharacterFoliageEffect();
					this.FoliageEffect.Start(this.OwnerCharacter);
					this.FoliageEffect.Enable();
				}
			}
			bool flag = true;
			this.IsEnable = false;
			this.TempVector = Vector.Create();
			this.ActorSpeed = Vector.Create();
			if (this.OwnerCharacter != null)
			{
				this.ActorLocation = new FVectorDouble?(this.OwnerCharacter.D_K2_GetActorLocation());
				this.TsActorLocation = Vector.Create(this.ActorLocation.Value);
				this.TsPreviousActorLocation = Vector.Create(this.ActorLocation.Value);
			}
			if (flag)
			{
				this.UpdateWaterStateInternal = this.UpdateWaterStateInternalPc;
			}
			this.UpdateWaterStateInternal *= this.UpdateWaterStateInternalScale;
		}

		// Token: 0x0602F7F7 RID: 194551 RVA: 0x00B4C2B8 File Offset: 0x00B4A4B8
		public void Enable()
		{
			Log instance = Singleton<Log>.Instance;
			ELogModule module = ELogModule.RenderEffect;
			ELogAuthor author = ELogAuthor.LSY;
			string message = "交互配置启用";
			ValueTuple<string, object> valueTuple = new ValueTuple<string, object>("Actor", this.OwnerCharacter);
			instance.Info(module, author, message, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple));
			SceneCharacterInteraction.InitTraceInfo();
			this.IsEnable = true;
			if (this.OwnerCharacter != null)
			{
				this.EnviInteractionComponent = (this.OwnerCharacter.GetComponentByClass(UKuroEnviInteractionComponent.StaticClass()) as UKuroEnviInteractionComponent);
			}
			if (this.EnviInteractionComponent != null)
			{
				this.EnviInteractionComponent.bUpdateWaterEID = true;
				this.EnviInteractionComponent.bUpdateRainOcclusion = true;
			}
			TsBaseCharacter ownerCharacter = this.OwnerCharacter;
			if (((ownerCharacter != null) ? ownerCharacter.CapsuleComponent : null) != null)
			{
				this.CheckInWater(0f);
			}
		}

		// Token: 0x0602F7F8 RID: 194552 RVA: 0x00B4C364 File Offset: 0x00B4A564
		public void Disable()
		{
			Log instance = Singleton<Log>.Instance;
			ELogModule module = ELogModule.RenderEffect;
			ELogAuthor author = ELogAuthor.LSY;
			string message = "交互配置禁用";
			ValueTuple<string, object> valueTuple = new ValueTuple<string, object>("Actor", this.OwnerCharacter);
			instance.Info(module, author, message, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple));
			this.IsEnable = false;
			this.ClearInWaterOrOnMaterialState();
			SceneCharacterWaterEffect waterEffect = this.WaterEffect;
			if (waterEffect != null)
			{
				waterEffect.Disable();
			}
			SceneCharacterTriggerEffect triggerEffect = this.TriggerEffect;
			if (triggerEffect != null)
			{
				triggerEffect.Disable();
			}
			SceneCharacterFoliageEffect foliageEffect = this.FoliageEffect;
			if (foliageEffect != null)
			{
				foliageEffect.Disable();
			}
			if (this.EnviInteractionComponent != null)
			{
				this.EnviInteractionComponent.bUpdateWaterEID = false;
				this.EnviInteractionComponent.bUpdateRainOcclusion = false;
			}
		}

		// Token: 0x0602F7F9 RID: 194553 RVA: 0x00B4C3FD File Offset: 0x00B4A5FD
		public bool GetEnabled()
		{
			return this.IsEnable;
		}

		// Token: 0x0602F7FA RID: 194554 RVA: 0x00B4C405 File Offset: 0x00B4A605
		public void Destroy()
		{
			this.Disable();
		}

		// Token: 0x0602F7FB RID: 194555 RVA: 0x00B4C40D File Offset: 0x00B4A60D
		public void ClearInWaterOrOnMaterialState()
		{
			this.IsInWaterOrOnMaterial = false;
			this.PhysicalMaterial = null;
		}

		// Token: 0x0602F7FC RID: 194556 RVA: 0x00B4C420 File Offset: 0x00B4A620
		private static void InitTraceInfo()
		{
			UTraceSphereElement utraceSphereElement = new UTraceSphereElement();
			utraceSphereElement.WorldContextObject = GlobalData.World;
			utraceSphereElement.bIsSingle = false;
			utraceSphereElement.bIgnoreSelf = true;
			utraceSphereElement.Radius = 1f;
			TArray<TEnumAsByte<EObjectTypeQuery>> tarray = new TArray<TEnumAsByte<EObjectTypeQuery>>();
			tarray.Add(KuroObjectTypeQuery.WorldStatic);
			tarray.Add(KuroObjectTypeQuery.KuroWater);
			utraceSphereElement.SetObjectTypesQuery(ref tarray);
			utraceSphereElement.DrawTime = 10f;
			Singleton<TraceElementCommon>.Instance.SetTraceColor(utraceSphereElement, ColorUtils.LinearGreen);
			Singleton<TraceElementCommon>.Instance.SetTraceHitColor(utraceSphereElement, ColorUtils.LinearRed);
			utraceSphereElement.SetDrawDebugTrace(EDrawDebugTrace.None);
			SceneCharacterInteraction.SphereTrace = utraceSphereElement;
		}

		// Token: 0x0602F7FD RID: 194557 RVA: 0x00B4C4BD File Offset: 0x00B4A6BD
		public static void SetTraceDebug(bool enable)
		{
			if (SceneCharacterInteraction.SphereTrace != null)
			{
				SceneCharacterInteraction.SphereTrace.SetDrawDebugTrace(enable ? EDrawDebugTrace.ForDuration : EDrawDebugTrace.None);
			}
		}

		// Token: 0x0602F7FE RID: 194558 RVA: 0x00B4C4D8 File Offset: 0x00B4A6D8
		protected void CheckInWater(float delta)
		{
			if (this.UseCppCheck)
			{
				if (this.EnviInteractionData != null)
				{
					FVectorDouble fvectorDouble = this.OwnerCharacter.CapsuleComponent.D_K2_GetComponentLocation();
					this.WaterHeight = Vector.Distance(Vector.Create(this.EnviInteractionData.HitWaterLocation), Vector.Create(fvectorDouble));
					this.WaterNormal = Vector.Create(this.EnviInteractionData.HitWaterNormal);
					if (this.EnviInteractionData.bInWater)
					{
						this.SetInWater();
						return;
					}
					if (this.EnviInteractionData.HitPhysicMaterial == null)
					{
						UPhysicalMaterial globalFootstepMaterial = Singleton<RenderDataManager>.Instance.GetGlobalFootstepMaterial();
						this.EnviInteractionData.HitPhysicMaterial = globalFootstepMaterial;
					}
					if (this.EnviInteractionData.HitPhysicMaterial != null)
					{
						SceneCharacterWaterEffect waterEffect = this.WaterEffect;
						if (waterEffect != null && waterEffect.IsMaterialInUse(this.EnviInteractionData.HitPhysicMaterial))
						{
							this.SetOnMaterial(this.EnviInteractionData.HitPhysicMaterial);
							return;
						}
					}
				}
				this.ClearInWaterOrOnMaterialState();
				return;
			}
			PDA_InteractionPlayerConfig_C config = this.Config;
			if (config != null && config.启用水面交互)
			{
				if (SceneCharacterInteraction.SphereTrace == null)
				{
					SceneCharacterInteraction.InitTraceInfo();
				}
				UCapsuleComponent capsuleComponent = this.OwnerCharacter.CapsuleComponent;
				FVectorDouble fvectorDouble2 = capsuleComponent.D_K2_GetComponentLocation();
				FVectorDouble fvectorDouble3 = new FVectorDouble(0.0, 0.0, (double)capsuleComponent.CapsuleHalfHeight);
				FVectorDouble fvectorDouble4 = new FVectorDouble(0.0, 0.0, (double)(-(double)capsuleComponent.CapsuleHalfHeight - this.Config.射线向下延长));
				Vector location = Vector.Create(fvectorDouble2.X + fvectorDouble3.X, fvectorDouble2.Y + fvectorDouble3.Y, fvectorDouble2.Z + fvectorDouble3.Z);
				Vector location2 = Vector.Create(fvectorDouble2.X + fvectorDouble4.X, fvectorDouble2.Y + fvectorDouble4.Y, fvectorDouble2.Z + fvectorDouble4.Z);
				Singleton<TraceElementCommon>.Instance.SetStartLocation(SceneCharacterInteraction.SphereTrace, location);
				Singleton<TraceElementCommon>.Instance.SetEndLocation(SceneCharacterInteraction.SphereTrace, location2);
				bool flag = Singleton<TraceElementCommon>.Instance.SphereTrace(SceneCharacterInteraction.SphereTrace, "SceneCharacterInteraction_CheckInWater");
				UTraceSphereElement sphereTrace = SceneCharacterInteraction.SphereTrace;
				UKuroHitResult ukuroHitResult = (sphereTrace != null) ? sphereTrace.HitResult : null;
				if (flag && ukuroHitResult != null && ukuroHitResult.bBlockingHit)
				{
					int hitCount = ukuroHitResult.GetHitCount();
					UPhysicalMaterial globalFootstepMaterial2 = Singleton<RenderDataManager>.Instance.GetGlobalFootstepMaterial();
					for (int i = 0; i < hitCount; i++)
					{
						UPrimitiveComponent uprimitiveComponent = ukuroHitResult.Components.Get(i).Get();
						TEnumAsByte<ECollisionResponse>? tenumAsByte = (uprimitiveComponent != null) ? new TEnumAsByte<ECollisionResponse>?(uprimitiveComponent.BodyInstance.CollisionResponses.ResponseToChannels.GameTraceChannel2) : null;
						int? num = (tenumAsByte != null) ? new int?((int)tenumAsByte.GetValueOrDefault()) : null;
						int num2 = 2;
						if (num.GetValueOrDefault() == num2 & num != null)
						{
							this.WaterHeight = (double)ukuroHitResult.LocationZ_Array.Get(i);
							this.WaterNormal = Vector.Create((double)ukuroHitResult.ImpactNormalX_Array.Get(i), (double)ukuroHitResult.ImpactNormalY_Array.Get(i), (double)ukuroHitResult.ImpactNormalZ_Array.Get(i));
							this.SetInWater();
							return;
						}
						UPrimitiveComponent uprimitiveComponent2 = ukuroHitResult.Components.Get(i).Get();
						if (uprimitiveComponent2 is ULandscapeHeightfieldCollisionComponent)
						{
							this.PhysicalMaterial = ukuroHitResult.PhysMaterials.Get(i);
							if (this.PhysicalMaterial == null || !this.WaterEffect.IsMaterialInUse(this.PhysicalMaterial))
							{
								this.PhysicalMaterial = globalFootstepMaterial2;
							}
						}
						else
						{
							tenumAsByte = ((uprimitiveComponent2 != null) ? new TEnumAsByte<ECollisionResponse>?(uprimitiveComponent2.BodyInstance.CollisionResponses.ResponseToChannels.WorldStatic) : null);
							num = ((tenumAsByte != null) ? new int?((int)tenumAsByte.GetValueOrDefault()) : null);
							num2 = 2;
							if (num.GetValueOrDefault() == num2 & num != null)
							{
								this.PhysicalMaterial = UKuroRenderingRuntimeBPPluginBPLibrary.GetComponentPhysicalMaterial(uprimitiveComponent2);
								if (this.PhysicalMaterial == null || !this.WaterEffect.IsMaterialInUse(this.PhysicalMaterial))
								{
									this.PhysicalMaterial = globalFootstepMaterial2;
								}
							}
						}
						if (this.PhysicalMaterial != null && this.WaterEffect.IsMaterialInUse(this.PhysicalMaterial))
						{
							this.WaterHeight = (double)ukuroHitResult.LocationZ_Array.Get(i);
							this.WaterNormal = Vector.Create((double)ukuroHitResult.ImpactNormalX_Array.Get(i), (double)ukuroHitResult.ImpactNormalY_Array.Get(i), (double)ukuroHitResult.ImpactNormalZ_Array.Get(i));
							this.SetOnMaterial(this.PhysicalMaterial);
							return;
						}
						tenumAsByte = ((uprimitiveComponent2 != null) ? new TEnumAsByte<ECollisionResponse>?(uprimitiveComponent2.BodyInstance.CollisionResponses.ResponseToChannels.WorldStatic) : null);
						num = ((tenumAsByte != null) ? new int?((int)tenumAsByte.GetValueOrDefault()) : null);
						num2 = 2;
						if (num.GetValueOrDefault() == num2 & num != null)
						{
							break;
						}
					}
				}
				this.ClearInWaterOrOnMaterialState();
			}
		}

		// Token: 0x0602F7FF RID: 194559 RVA: 0x00B4CA08 File Offset: 0x00B4AC08
		public static void CreateStaticDefaultValue()
		{
		}

		// Token: 0x0602F800 RID: 194560 RVA: 0x00B4CA0A File Offset: 0x00B4AC0A
		public static void ResetStaticDefaultValue()
		{
			SceneCharacterInteraction.SphereTrace = null;
		}

		// Token: 0x0401B240 RID: 111168
		public TsBaseCharacter OwnerCharacter;

		// Token: 0x0401B241 RID: 111169
		public UKuroEnviInteractionComponent EnviInteractionComponent;

		// Token: 0x0401B242 RID: 111170
		public FVectorDouble? ActorLocation;

		// Token: 0x0401B243 RID: 111171
		public Vector TsActorLocation;

		// Token: 0x0401B244 RID: 111172
		public Vector TsPreviousActorLocation;

		// Token: 0x0401B245 RID: 111173
		public Vector ActorSpeed;

		// Token: 0x0401B246 RID: 111174
		protected PDA_InteractionPlayerConfig_C Config;

		// Token: 0x0401B247 RID: 111175
		protected SceneCharacterWaterEffect WaterEffect;

		// Token: 0x0401B248 RID: 111176
		protected SceneCharacterTriggerEffect TriggerEffect;

		// Token: 0x0401B249 RID: 111177
		protected SceneCharacterFoliageEffect FoliageEffect;

		// Token: 0x0401B24A RID: 111178
		protected double CapsuleHalfHeight;

		// Token: 0x0401B24B RID: 111179
		protected bool IsEnable;

		// Token: 0x0401B24C RID: 111180
		protected bool IsInWaterOrOnMaterial;

		// Token: 0x0401B24D RID: 111181
		protected bool IsInAudioShr;

		// Token: 0x0401B24E RID: 111182
		protected FName? AudioShrTag;

		// Token: 0x0401B24F RID: 111183
		protected UPhysicalMaterial PhysicalMaterial;

		// Token: 0x0401B250 RID: 111184
		protected double WaterHeight;

		// Token: 0x0401B251 RID: 111185
		protected Vector WaterNormal;

		// Token: 0x0401B252 RID: 111186
		protected float UpdateWaterStateInternal = 0.3f;

		// Token: 0x0401B253 RID: 111187
		protected float UpdateWaterStateInternalPc = 0.15f;

		// Token: 0x0401B254 RID: 111188
		protected float UpdateWaterStateInternalScale = 1f;

		// Token: 0x0401B255 RID: 111189
		protected float UpdateWaterStateCounter;

		// Token: 0x0401B256 RID: 111190
		protected bool UseCppCheck;

		// Token: 0x0401B257 RID: 111191
		protected FKuroEnviInteractionData EnviInteractionData;

		// Token: 0x0401B258 RID: 111192
		private static readonly FName NoCollisionProfileName = new FName("NoCollision");

		// Token: 0x0401B259 RID: 111193
		[Nullable(1)]
		private const string PROFILE_KEY = "SceneCharacterInteraction_CheckInWater";

		// Token: 0x0401B25A RID: 111194
		[Nullable(1)]
		private const string AUDIO_TAG_PREFIX = "Audio_";

		// Token: 0x0401B25C RID: 111196
		private static UTraceSphereElement SphereTrace = null;

		// Token: 0x0401B25D RID: 111197
		private const bool DebugWaterTrace = false;
	}
}
