using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using AkiClient.Game.Aki.Data.Gameplay.MotorRailMove.Struct;

namespace CSharpScript.Game.NewWorld.Vehicle.Motorcycle.MotorcycleRailMove
{
	// Token: 0x020047C3 RID: 18371
	[NullableContext(1)]
	[Nullable(0)]
	public class RailMoveEventHandler
	{
		// Token: 0x0602FAD9 RID: 195289 RVA: 0x00B6700C File Offset: 0x00B6520C
		public void UpdateFromUeData(SMotorRailMove_EventHandler data)
		{
			this.ModifyCues.Clear();
			foreach (KeyValuePair<int, bool> keyValuePair in data.ModifyCues)
			{
				int num;
				bool flag;
				keyValuePair.Deconstruct(out num, out flag);
				int key = num;
				bool value = flag;
				this.ModifyCues[key] = value;
			}
		}

		// Token: 0x0602FADA RID: 195290 RVA: 0x00B6707C File Offset: 0x00B6527C
		public void DeepCopy(RailMoveEventHandler other)
		{
			this.ModifyCues.Clear();
			foreach (KeyValuePair<int, bool> keyValuePair in other.ModifyCues)
			{
				int num;
				bool flag;
				keyValuePair.Deconstruct(out num, out flag);
				int key = num;
				bool value = flag;
				this.ModifyCues[key] = value;
			}
		}

		// Token: 0x0401B4CC RID: 111820
		public Dictionary<int, bool> ModifyCues = new Dictionary<int, bool>();
	}
}
