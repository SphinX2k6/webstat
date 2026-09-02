using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;

// Token: 0x02002FB5 RID: 12213
public class GameplayCueReference : GameplayCueBase
{
	// Token: 0x06018E7E RID: 102014 RVA: 0x0070E1C0 File Offset: 0x0070C3C0
	protected override void OnInit()
	{
		int parametersLength = this.CueConfig.ParametersLength;
		if (parametersLength > 0)
		{
			this.OtherEntityType = (GameplayCueReference.EOtherEntityType)int.Parse(this.CueConfig.Parameters(0));
		}
		if (parametersLength > 1)
		{
			foreach (string s in this.CueConfig.Parameters(1).Split('#', StringSplitOptions.None))
			{
				this.ReferenceCueConfigIds.Add(long.Parse(s));
			}
		}
	}

	// Token: 0x06018E7F RID: 102015 RVA: 0x0070E230 File Offset: 0x0070C430
	protected override void OnCreate()
	{
		if (this.ReferenceCueConfigIds.Count > 0)
		{
			BaseGameplayCueComponent gameplayCueComponent = this.GetGameplayCueComponent();
			if (gameplayCueComponent != null)
			{
				this.OtherEntityCueComp = new WeakReference<BaseGameplayCueComponent>(gameplayCueComponent);
				foreach (long cueId in this.ReferenceCueConfigIds)
				{
					int num = gameplayCueComponent.AddCue(cueId, new GameplayCueParam?(new GameplayCueParam
					{
						Instant = this.IsInstant
					}));
					if (num != 0 && num != -1)
					{
						this.ReferenceCueHandles.Add(num);
					}
				}
			}
		}
	}

	// Token: 0x06018E80 RID: 102016 RVA: 0x0070E2D8 File Offset: 0x0070C4D8
	protected override void OnDestroy()
	{
		BaseGameplayCueComponent baseGameplayCueComponent;
		if (this.ReferenceCueHandles.Count > 0 && this.OtherEntityCueComp != null && this.OtherEntityCueComp.TryGetTarget(out baseGameplayCueComponent))
		{
			foreach (int num in this.ReferenceCueHandles)
			{
				baseGameplayCueComponent.RemoveCueByHandle((long)num);
			}
		}
		this.ReferenceCueConfigIds.Clear();
		this.ReferenceCueHandles.Clear();
		this.OtherEntityCueComp = null;
	}

	// Token: 0x06018E81 RID: 102017 RVA: 0x0070E370 File Offset: 0x0070C570
	[NullableContext(2)]
	private BaseGameplayCueComponent GetGameplayCueComponent()
	{
		if (this.OtherEntityType != GameplayCueReference.EOtherEntityType.Vehicle)
		{
			return null;
		}
		WorldEntity entity = this.EntityHandle.Entity;
		if (entity == null)
		{
			return null;
		}
		CharacterDriveVehicleComponent component = entity.GetComponent<CharacterDriveVehicleComponent>();
		if (component == null)
		{
			return null;
		}
		Entity vehicleEntity = component.VehicleEntity;
		if (vehicleEntity == null)
		{
			return null;
		}
		return vehicleEntity.GetComponent<BaseGameplayCueComponent>();
	}

	// Token: 0x0400C2A0 RID: 49824
	private GameplayCueReference.EOtherEntityType OtherEntityType = GameplayCueReference.EOtherEntityType.None;

	// Token: 0x0400C2A1 RID: 49825
	[Nullable(1)]
	private readonly List<long> ReferenceCueConfigIds = new List<long>();

	// Token: 0x0400C2A2 RID: 49826
	[Nullable(1)]
	private readonly List<int> ReferenceCueHandles = new List<int>();

	// Token: 0x0400C2A3 RID: 49827
	[Nullable(new byte[]
	{
		2,
		1
	})]
	private WeakReference<BaseGameplayCueComponent> OtherEntityCueComp;

	// Token: 0x0200933E RID: 37694
	private enum EOtherEntityType
	{
		// Token: 0x04031048 RID: 200776
		None = -1,
		// Token: 0x04031049 RID: 200777
		Vehicle
	}
}
