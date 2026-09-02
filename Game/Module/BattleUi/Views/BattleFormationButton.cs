using System;
using System.Runtime.CompilerServices;
using CSharpScript.Game.Common.Event;
using UnrealEngine;

namespace CSharpScript.Game.Module.BattleUi.Views
{
	// Token: 0x02005FBB RID: 24507
	public class BattleFormationButton : BattleEntranceButton
	{
		// Token: 0x0603D9F2 RID: 252402 RVA: 0x00FB2C57 File Offset: 0x00FB0E57
		protected override void OnRegisterComponent()
		{
			base.OnRegisterComponent();
			this.ComponentRegisterInfos.Add(new ValueTuple<int, Type>(2, typeof(UUISprite)));
		}

		// Token: 0x0603D9F3 RID: 252403 RVA: 0x00FB2C7A File Offset: 0x00FB0E7A
		protected void AddEvents()
		{
			Singleton<EventSystem>.Instance.Add(EEventName.OnEnterVehicleRideSharing, new Action<VehiclePassengerInfo>(this.OnEnterVehicleRideSharing));
			Singleton<EventSystem>.Instance.Add(EEventName.OnLeaveVehicleRideSharing, new Action<VehiclePassengerInfo>(this.OnLeaveVehicleRideSharing));
		}

		// Token: 0x0603D9F4 RID: 252404 RVA: 0x00FB2CB4 File Offset: 0x00FB0EB4
		protected void RemoveEvents()
		{
			Singleton<EventSystem>.Instance.Remove(EEventName.OnEnterVehicleRideSharing, new Action<VehiclePassengerInfo>(this.OnEnterVehicleRideSharing));
			Singleton<EventSystem>.Instance.Remove(EEventName.OnLeaveVehicleRideSharing, new Action<VehiclePassengerInfo>(this.OnLeaveVehicleRideSharing));
		}

		// Token: 0x0603D9F5 RID: 252405 RVA: 0x00FB2CEE File Offset: 0x00FB0EEE
		[NullableContext(2)]
		public override void Initialize(object param = null)
		{
			base.Initialize(param);
			this.AddEvents();
		}

		// Token: 0x0603D9F6 RID: 252406 RVA: 0x00FB2CFD File Offset: 0x00FB0EFD
		public override void Reset()
		{
			this.RemoveEvents();
			base.Reset();
		}

		// Token: 0x0603D9F7 RID: 252407 RVA: 0x00FB2D0B File Offset: 0x00FB0F0B
		[NullableContext(1)]
		private void OnEnterVehicleRideSharing(VehiclePassengerInfo info)
		{
		}

		// Token: 0x0603D9F8 RID: 252408 RVA: 0x00FB2D0D File Offset: 0x00FB0F0D
		[NullableContext(1)]
		private void OnLeaveVehicleRideSharing(VehiclePassengerInfo info)
		{
		}

		// Token: 0x0200C020 RID: 49184
		private enum EChildType
		{
			// Token: 0x0403B254 RID: 242260
			Button,
			// Token: 0x0403B255 RID: 242261
			RedDotItem,
			// Token: 0x0403B256 RID: 242262
			IconSprite
		}
	}
}
