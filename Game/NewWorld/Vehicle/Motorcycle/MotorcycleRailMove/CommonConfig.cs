using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using AkiClient.Game.Aki.Data.Gameplay.MotorRailMove.Struct;
using UnrealEngine;

namespace CSharpScript.Game.NewWorld.Vehicle.Motorcycle.MotorcycleRailMove
{
	// Token: 0x020047B8 RID: 18360
	[NullableContext(1)]
	[Nullable(0)]
	public class CommonConfig
	{
		// Token: 0x0602FAB8 RID: 195256 RVA: 0x00B65EF4 File Offset: 0x00B640F4
		public void UpdateFromUeData(SMotorRailMove_CommonConfig data)
		{
			this.ModifyVehicleTagsOnEnter.Clear();
			foreach (KeyValuePair<FGameplayTag, bool> keyValuePair in data.ModifyVehicleTagsOnEnter)
			{
				FGameplayTag fgameplayTag;
				bool flag;
				keyValuePair.Deconstruct(out fgameplayTag, out flag);
				FGameplayTag tag = fgameplayTag;
				bool value = flag;
				this.ModifyVehicleTagsOnEnter[tag.TagId()] = value;
			}
			this.ModifyVehicleTagsOnExit.Clear();
			foreach (KeyValuePair<FGameplayTag, bool> keyValuePair in data.ModifyVehicleTagsOnExit)
			{
				FGameplayTag fgameplayTag;
				bool flag;
				keyValuePair.Deconstruct(out fgameplayTag, out flag);
				FGameplayTag tag2 = fgameplayTag;
				bool value2 = flag;
				this.ModifyVehicleTagsOnExit[tag2.TagId()] = value2;
			}
			this.EnableBlockingCheck = data.EnableBlockingCheck;
			this.MaxBlockingTimeOut = data.MaxBlockingTimeOut;
		}

		// Token: 0x0602FAB9 RID: 195257 RVA: 0x00B65FE8 File Offset: 0x00B641E8
		public void DeepCopy(CommonConfig other)
		{
			this.ModifyVehicleTagsOnEnter.Clear();
			foreach (KeyValuePair<int, bool> keyValuePair in other.ModifyVehicleTagsOnEnter)
			{
				int num;
				bool flag;
				keyValuePair.Deconstruct(out num, out flag);
				int key = num;
				bool value = flag;
				this.ModifyVehicleTagsOnEnter[key] = value;
			}
			this.ModifyVehicleTagsOnExit.Clear();
			foreach (KeyValuePair<int, bool> keyValuePair in other.ModifyVehicleTagsOnExit)
			{
				int num;
				bool flag;
				keyValuePair.Deconstruct(out num, out flag);
				int key2 = num;
				bool value2 = flag;
				this.ModifyVehicleTagsOnExit[key2] = value2;
			}
			this.EnableBlockingCheck = other.EnableBlockingCheck;
			this.MaxBlockingTimeOut = other.MaxBlockingTimeOut;
		}

		// Token: 0x0401B49A RID: 111770
		public readonly Dictionary<int, bool> ModifyVehicleTagsOnEnter = new Dictionary<int, bool>();

		// Token: 0x0401B49B RID: 111771
		public readonly Dictionary<int, bool> ModifyVehicleTagsOnExit = new Dictionary<int, bool>();

		// Token: 0x0401B49C RID: 111772
		public bool EnableBlockingCheck;

		// Token: 0x0401B49D RID: 111773
		public float MaxBlockingTimeOut;
	}
}
