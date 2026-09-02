using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using AkiClient.Game.Aki.Character.Vehicle.Motor;
using AkiClient.Game.Aki.Character.Vehicle.Motor.Data;
using AkiClient.Game.Aki.Data.Level.Vehicle;
using UnrealEngine;

namespace CSharpScript.Game.NewWorld.Vehicle.Motorcycle
{
	// Token: 0x020047B1 RID: 18353
	[NullableContext(2)]
	[Nullable(0)]
	public class MotorcycleConfigComponent : EntityComponent
	{
		// Token: 0x170081C5 RID: 33221
		// (get) Token: 0x0602FA23 RID: 195107 RVA: 0x00B5EA7C File Offset: 0x00B5CC7C
		private bool HasConfigData
		{
			get
			{
				TsBaseVehicle motorActor = this.MotorActor;
				return motorActor is BP_Motor_BaseVehicle_C || motorActor is BP_Motor_BaseVehicle_MINI_BugFinder_C || motorActor is BP_Motor_BaseVehicle_Photo_C;
			}
		}

		// Token: 0x0602FA24 RID: 195108 RVA: 0x00B5EAB0 File Offset: 0x00B5CCB0
		private void GetConfigDataByKeyName(FName name, ref SMotorConfigs config)
		{
			TsBaseVehicle motorActor = this.MotorActor;
			BP_Motor_BaseVehicle_C bp_Motor_BaseVehicle_C = motorActor as BP_Motor_BaseVehicle_C;
			if (bp_Motor_BaseVehicle_C != null)
			{
				bp_Motor_BaseVehicle_C.GetConfigDataByKeyName(name, ref config);
				return;
			}
			BP_Motor_BaseVehicle_MINI_BugFinder_C bp_Motor_BaseVehicle_MINI_BugFinder_C = motorActor as BP_Motor_BaseVehicle_MINI_BugFinder_C;
			if (bp_Motor_BaseVehicle_MINI_BugFinder_C != null)
			{
				bp_Motor_BaseVehicle_MINI_BugFinder_C.GetConfigDataByKeyName(name, ref config);
				return;
			}
			BP_Motor_BaseVehicle_Photo_C bp_Motor_BaseVehicle_Photo_C = motorActor as BP_Motor_BaseVehicle_Photo_C;
			if (bp_Motor_BaseVehicle_Photo_C == null)
			{
				return;
			}
			bp_Motor_BaseVehicle_Photo_C.GetConfigDataByKeyName(name, ref config);
		}

		// Token: 0x0602FA25 RID: 195109 RVA: 0x00B5EB00 File Offset: 0x00B5CD00
		protected unsafe override bool OnStart()
		{
			this.TagComp = base.Entity.GetComponent<VehicleTagComponent>();
			if (this.TagComp == null)
			{
				return false;
			}
			VehicleActorComponent component = base.Entity.GetComponent<VehicleActorComponent>();
			this.MotorActor = ((component != null) ? component.Actor : null);
			if (!this.HasConfigData)
			{
				return false;
			}
			this.ConfigHelper = this.MotorActor.VehicleMovementComponent.MotorConfigHelper;
			if (this.ConfigHelper == null)
			{
				this.ConfigHelper = new UKuroConfigHelper(this.MotorActor.VehicleMovementComponent, "MotorConfigHelper", EObjectFlags.RF_NoFlags);
				this.MotorActor.VehicleMovementComponent.MotorConfigHelper = this.ConfigHelper;
			}
			TArray<FName> tarray = new TArray<FName>();
			UKuroVehicleMovementComponent vehicleMovementComponent = this.MotorActor.VehicleMovementComponent;
			UDataTableFunctionLibrary.GetDataTableRowNames((vehicleMovementComponent != null) ? vehicleMovementComponent.MotorConfigDataTable : null, ref tarray);
			int num = tarray.Num();
			this.TagIdToConfigParams.Clear();
			for (int i = 0; i < num; i++)
			{
				FName fname = tarray.Get(i);
				SMotorConfigs smotorConfigs = new SMotorConfigs();
				this.GetConfigDataByKeyName(fname, ref smotorConfigs);
				if (fname == MotorcycleConfigComponent.baseName)
				{
					this.ConfigHelper.InitBase(this.MotorActor.VehicleMovementComponent, smotorConfigs.Configs);
				}
				else
				{
					MotorcycleConfigComponent.MotorConfigParams motorConfigParams = new MotorcycleConfigComponent.MotorConfigParams(fname, smotorConfigs, this.TagComp, this.ConfigHelper);
					TArray<FGameplayTag> gameplayTags = smotorConfigs.ActivateTags.GameplayTags;
					int num2 = gameplayTags.Num();
					for (int j = 0; j < num2; j++)
					{
						FGameplayTag fgameplayTag = gameplayTags.Get(j);
						if (!(fgameplayTag.TagName == "None"))
						{
							List<MotorcycleConfigComponent.MotorConfigParams> valueOrDefault = this.TagIdToConfigParams.GetValueOrDefault(fgameplayTag.TagId());
							if (valueOrDefault != null)
							{
								valueOrDefault.Add(motorConfigParams);
							}
							else
							{
								Dictionary<int, List<MotorcycleConfigComponent.MotorConfigParams>> tagIdToConfigParams = this.TagIdToConfigParams;
								int key = fgameplayTag.TagId();
								int num3 = 1;
								List<MotorcycleConfigComponent.MotorConfigParams> list = new List<MotorcycleConfigComponent.MotorConfigParams>(num3);
								CollectionsMarshal.SetCount<MotorcycleConfigComponent.MotorConfigParams>(list, num3);
								Span<MotorcycleConfigComponent.MotorConfigParams> span = CollectionsMarshal.AsSpan<MotorcycleConfigComponent.MotorConfigParams>(list);
								int num4 = 0;
								*span[num4] = motorConfigParams;
								tagIdToConfigParams.Add(key, list);
							}
						}
					}
					motorConfigParams.TryActivate();
				}
			}
			foreach (KeyValuePair<int, List<MotorcycleConfigComponent.MotorConfigParams>> keyValuePair in this.TagIdToConfigParams)
			{
				int num4;
				List<MotorcycleConfigComponent.MotorConfigParams> list2;
				keyValuePair.Deconstruct(out num4, out list2);
				int tagId = num4;
				this.TagComp.AddTagAddOrRemoveListener(tagId, new BaseTagComponent.TTagSwitchedCallback(this.OnTagChanged), null);
			}
			BaseVehiclePerformComponent component2 = base.Entity.GetComponent<BaseVehiclePerformComponent>();
			object obj;
			if (component2 == null)
			{
				obj = null;
			}
			else
			{
				VehicleConfig config = component2.Config;
				obj = ((config != null) ? config.Asset : null);
			}
			BP_MotorConfig_C bp_MotorConfig_C = obj as BP_MotorConfig_C;
			if (bp_MotorConfig_C == null)
			{
				return true;
			}
			UDataTable configDataTable = bp_MotorConfig_C.ConfigDataTable;
			if (configDataTable != null)
			{
				this.MotorActor.VehicleMovementComponent.MotorConfigDataTable = configDataTable;
			}
			return true;
		}

		// Token: 0x0602FA26 RID: 195110 RVA: 0x00B5EDB8 File Offset: 0x00B5CFB8
		protected override bool OnEnd()
		{
			foreach (KeyValuePair<int, List<MotorcycleConfigComponent.MotorConfigParams>> keyValuePair in this.TagIdToConfigParams)
			{
				int num;
				List<MotorcycleConfigComponent.MotorConfigParams> list;
				keyValuePair.Deconstruct(out num, out list);
				int tagId = num;
				this.TagComp.RemoveTagAddOrRemoveListener(tagId, new BaseTagComponent.TTagSwitchedCallback(this.OnTagChanged));
			}
			return true;
		}

		// Token: 0x0602FA27 RID: 195111 RVA: 0x00B5EE2C File Offset: 0x00B5D02C
		private void OnTagChanged(int tagId, bool tagExist)
		{
			if (this.MotorActor == null)
			{
				return;
			}
			List<MotorcycleConfigComponent.MotorConfigParams> valueOrDefault = this.TagIdToConfigParams.GetValueOrDefault(tagId);
			if (valueOrDefault == null)
			{
				return;
			}
			if (tagExist)
			{
				using (List<MotorcycleConfigComponent.MotorConfigParams>.Enumerator enumerator = valueOrDefault.GetEnumerator())
				{
					while (enumerator.MoveNext())
					{
						MotorcycleConfigComponent.MotorConfigParams motorConfigParams = enumerator.Current;
						motorConfigParams.TryActivate();
					}
					return;
				}
			}
			foreach (MotorcycleConfigComponent.MotorConfigParams motorConfigParams2 in valueOrDefault)
			{
				motorConfigParams2.Inactivate();
			}
		}

		// Token: 0x0602FA28 RID: 195112 RVA: 0x00B5EED0 File Offset: 0x00B5D0D0
		[NullableContext(1)]
		public override bool ClearComponent(EntityComponent componentTemplate)
		{
			if (!base.ClearComponent(componentTemplate))
			{
				return false;
			}
			MotorcycleConfigComponent motorcycleConfigComponent = (MotorcycleConfigComponent)componentTemplate;
			if (base.CanResetComponentProperty("TagComp"))
			{
				if (motorcycleConfigComponent.TagComp == null)
				{
					this.TagComp = null;
				}
				else if (!base.CheckClearObject(EntityComponentSystem.ClearObject<VehicleTagComponent>(this.TagComp), "TagComp"))
				{
					return false;
				}
			}
			if (base.CanResetComponentProperty("MotorActor"))
			{
				if (motorcycleConfigComponent.MotorActor == null)
				{
					this.MotorActor = null;
				}
				else if (!base.CheckClearObject(EntityComponentSystem.ClearObject<TsBaseVehicle>(this.MotorActor), "MotorActor"))
				{
					return false;
				}
			}
			if (base.CanResetComponentProperty("ConfigHelper"))
			{
				if (motorcycleConfigComponent.ConfigHelper == null)
				{
					this.ConfigHelper = null;
				}
				else if (!base.CheckClearObject(EntityComponentSystem.ClearObject<UKuroConfigHelper>(this.ConfigHelper), "ConfigHelper"))
				{
					return false;
				}
			}
			return !base.CanResetComponentProperty("TagIdToConfigParams") || motorcycleConfigComponent.TagIdToConfigParams == null || base.CheckClearObject(EntityComponentSystem.ClearObject<Dictionary<int, List<MotorcycleConfigComponent.MotorConfigParams>>>(this.TagIdToConfigParams), "TagIdToConfigParams");
		}

		// Token: 0x0401B410 RID: 111632
		[StaticVariableRuleIgnore]
		private static readonly FName baseName = new FName("Base");

		// Token: 0x0401B411 RID: 111633
		private VehicleTagComponent TagComp;

		// Token: 0x0401B412 RID: 111634
		private TsBaseVehicle MotorActor;

		// Token: 0x0401B413 RID: 111635
		private UKuroConfigHelper ConfigHelper;

		// Token: 0x0401B414 RID: 111636
		[Nullable(1)]
		private readonly Dictionary<int, List<MotorcycleConfigComponent.MotorConfigParams>> TagIdToConfigParams = new Dictionary<int, List<MotorcycleConfigComponent.MotorConfigParams>>();

		// Token: 0x0200A8A2 RID: 43170
		[NullableContext(1)]
		[Nullable(0)]
		public class MotorConfigParams
		{
			// Token: 0x0604AFAB RID: 307115 RVA: 0x01468D18 File Offset: 0x01466F18
			public static void ConvertVarNames([Nullable(new byte[]
			{
				1,
				0
			})] TArray<TEnumAsByte<EMotorPropertyName>> varNames, TArray<int> @out)
			{
				@out.Empty(true);
				int num = varNames.Num();
				for (int i = 0; i < num; i++)
				{
					@out.Add((int)varNames.Get(i));
				}
			}

			// Token: 0x0604AFAC RID: 307116 RVA: 0x01468D54 File Offset: 0x01466F54
			public MotorConfigParams(FName name, SMotorConfigs config, VehicleTagComponent tagComp, UKuroConfigHelper motorConfigHelper)
			{
				this.Name = name;
				this.Config = config;
				this.TagComp = tagComp;
				this.MotorConfigHelper = motorConfigHelper;
				TArray<FGameplayTag> gameplayTags = config.ActivateTags.GameplayTags;
				for (int i = gameplayTags.Num() - 1; i >= 0; i--)
				{
					this.Tags.Add(gameplayTags.Get(i).TagId());
				}
				MotorcycleConfigComponent.MotorConfigParams.ConvertVarNames(config.VarNames, this.VarInt);
			}

			// Token: 0x0604AFAD RID: 307117 RVA: 0x01468DE4 File Offset: 0x01466FE4
			public void TryActivate()
			{
				if (this.Activated)
				{
					return;
				}
				foreach (int tagId in this.Tags)
				{
					if (!this.TagComp.HasTag(tagId))
					{
						return;
					}
				}
				this.Activated = true;
				this.MotorConfigHelper.AddSubConfigByNumber(this.Name, this.Config.Priority, this.VarInt, this.Config.Configs);
				Log instance = Singleton<Log>.Instance;
				ELogModule module = ELogModule.Movement;
				ELogAuthor author = ELogAuthor.LCZ;
				string message = "MotorConfig AddSubConfig";
				ValueTuple<string, object> valueTuple = new ValueTuple<string, object>("Name", this.Name);
				instance.Info(module, author, message, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple));
			}

			// Token: 0x0604AFAE RID: 307118 RVA: 0x01468EB0 File Offset: 0x014670B0
			public void Inactivate()
			{
				if (!this.Activated)
				{
					return;
				}
				this.Activated = false;
				this.MotorConfigHelper.RemoveSubConfig(this.Name);
				Log instance = Singleton<Log>.Instance;
				ELogModule module = ELogModule.Movement;
				ELogAuthor author = ELogAuthor.LCZ;
				string message = "MotorConfig RemoveSubConfig";
				ValueTuple<string, object> valueTuple = new ValueTuple<string, object>("Name", this.Name);
				instance.Info(module, author, message, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple));
			}

			// Token: 0x04034515 RID: 214293
			private bool Activated;

			// Token: 0x04034516 RID: 214294
			private readonly List<int> Tags = new List<int>();

			// Token: 0x04034517 RID: 214295
			private readonly TArray<int> VarInt = new TArray<int>();

			// Token: 0x04034518 RID: 214296
			public FName Name;

			// Token: 0x04034519 RID: 214297
			private readonly SMotorConfigs Config;

			// Token: 0x0403451A RID: 214298
			private readonly VehicleTagComponent TagComp;

			// Token: 0x0403451B RID: 214299
			private readonly UKuroConfigHelper MotorConfigHelper;
		}
	}
}
