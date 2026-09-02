using System;
using System.Runtime.CompilerServices;
using CSharpScript.Game.Common.Event;
using CSharpScript.Game.Input;

// Token: 0x0200309E RID: 12446
[NullableContext(1)]
[Nullable(0)]
public class InputLayerHelper
{
	// Token: 0x06019A4D RID: 105037 RVA: 0x00774898 File Offset: 0x00772A98
	public void Init(EInputLayer layerType)
	{
		this.InputLayer = ControllerBase<InputController>.Instance.CreateInputLayer(layerType);
		Singleton<EventSystem>.Instance.Add<EntityHandle, EntityHandle>(EEventName.OnChangeRole, new Action<EntityHandle, EntityHandle>(this.OnChangeRole));
		Singleton<EventSystem>.Instance.Add<VehiclePassengerInfo, bool>(EEventName.OnEnterVehicle, new Action<VehiclePassengerInfo, bool>(this.OnEnterVehicle));
		Singleton<EventSystem>.Instance.Add<VehiclePassengerInfo, bool>(EEventName.OnLeaveVehicle, new Action<VehiclePassengerInfo, bool>(this.OnLeaveVehicle));
	}

	// Token: 0x06019A4E RID: 105038 RVA: 0x0077490C File Offset: 0x00772B0C
	public void Clear()
	{
		Singleton<EventSystem>.Instance.Remove(EEventName.OnChangeRole, new Action<EntityHandle, EntityHandle>(this.OnChangeRole));
		Singleton<EventSystem>.Instance.Remove<VehiclePassengerInfo, bool>(EEventName.OnEnterVehicle, new Action<VehiclePassengerInfo, bool>(this.OnEnterVehicle));
		Singleton<EventSystem>.Instance.Remove<VehiclePassengerInfo, bool>(EEventName.OnLeaveVehicle, new Action<VehiclePassengerInfo, bool>(this.OnLeaveVehicle));
		if (this.IsEnable)
		{
			this.RemoveInputLayer();
		}
		if (this.InputLayer != null)
		{
			this.InputLayer.Clear();
			this.InputLayer = null;
		}
	}

	// Token: 0x06019A4F RID: 105039 RVA: 0x00774995 File Offset: 0x00772B95
	public void AddInputLayer()
	{
		if (this.IsEnable)
		{
			return;
		}
		this.IsEnable = true;
		this.RefreshInputLayer();
	}

	// Token: 0x06019A50 RID: 105040 RVA: 0x007749AD File Offset: 0x00772BAD
	public void RemoveInputLayer()
	{
		if (!this.IsEnable)
		{
			return;
		}
		this.IsEnable = false;
		this.RefreshInputLayer();
	}

	// Token: 0x06019A51 RID: 105041 RVA: 0x007749C5 File Offset: 0x00772BC5
	[NullableContext(2)]
	public InputLayer GetInputLayer()
	{
		return this.InputLayer;
	}

	// Token: 0x06019A52 RID: 105042 RVA: 0x007749CD File Offset: 0x00772BCD
	private void OnChangeRole(EntityHandle newEntityHandle, [Nullable(2)] EntityHandle oldEntityHandle)
	{
		this.RefreshInputLayer();
	}

	// Token: 0x06019A53 RID: 105043 RVA: 0x007749D5 File Offset: 0x00772BD5
	private void OnEnterVehicle(VehiclePassengerInfo info, bool byChangeRole)
	{
		this.RefreshInputLayer();
	}

	// Token: 0x06019A54 RID: 105044 RVA: 0x007749DD File Offset: 0x00772BDD
	private void OnLeaveVehicle(VehiclePassengerInfo info, bool byChangeRole)
	{
		this.RefreshInputLayer();
	}

	// Token: 0x06019A55 RID: 105045 RVA: 0x007749E8 File Offset: 0x00772BE8
	private void RefreshInputLayer()
	{
		if (this.InputLayer == null)
		{
			return;
		}
		if (this.IsEnable)
		{
			EntityHandle getCurrentEntity = ModelBase<SceneTeamModel>.Instance.GetCurrentEntity;
			int? num = (getCurrentEntity != null) ? new int?(getCurrentEntity.Id) : null;
			CharacterDriveVehicleComponent characterDriveVehicleComponent;
			if (getCurrentEntity == null)
			{
				characterDriveVehicleComponent = null;
			}
			else
			{
				WorldEntity entity = getCurrentEntity.Entity;
				characterDriveVehicleComponent = ((entity != null) ? entity.GetComponent<CharacterDriveVehicleComponent>() : null);
			}
			CharacterDriveVehicleComponent characterDriveVehicleComponent2 = characterDriveVehicleComponent;
			if (characterDriveVehicleComponent2 != null)
			{
				Entity vehicleEntity = characterDriveVehicleComponent2.VehicleEntity;
				if (vehicleEntity != null && vehicleEntity.Valid)
				{
					Entity vehicleEntity2 = characterDriveVehicleComponent2.VehicleEntity;
					num = ((vehicleEntity2 != null) ? new int?(vehicleEntity2.Id) : null);
				}
			}
			int num2 = num.GetValueOrDefault();
			if (num == null)
			{
				num2 = 0;
				num = new int?(num2);
			}
			int? num3 = num;
			num2 = this.LayerEntityId;
			if (!(num3.GetValueOrDefault() == num2 & num3 != null))
			{
				this.LayerEntityId = num.Value;
				ControllerBase<InputController>.Instance.RemoveInputLayer(this.InputLayer);
				num3 = num;
				num2 = 0;
				if (!(num3.GetValueOrDefault() == num2 & num3 != null))
				{
					ControllerBase<InputController>.Instance.AddInputLayer(num.Value, this.InputLayer);
					return;
				}
			}
		}
		else if (this.LayerEntityId != 0)
		{
			this.LayerEntityId = 0;
			ControllerBase<InputController>.Instance.RemoveInputLayer(this.InputLayer);
		}
	}

	// Token: 0x0400CC3E RID: 52286
	[Nullable(2)]
	private InputLayer InputLayer;

	// Token: 0x0400CC3F RID: 52287
	private int LayerEntityId;

	// Token: 0x0400CC40 RID: 52288
	private bool IsEnable;
}
