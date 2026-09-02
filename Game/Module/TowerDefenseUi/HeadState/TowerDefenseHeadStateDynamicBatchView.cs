using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using CSharpScript.Game.Ui;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.CompilerServices;
using UnrealEngine;

namespace CSharpScript.Game.Module.TowerDefenseUi.HeadState
{
	// Token: 0x02004E7D RID: 20093
	[NullableContext(1)]
	[Nullable(0)]
	public class TowerDefenseHeadStateDynamicBatchView : UiPanelBase
	{
		// Token: 0x06033E95 RID: 212629 RVA: 0x00CFDC98 File Offset: 0x00CFBE98
		protected unsafe override void OnRegisterComponent()
		{
			int num = 2;
			List<ValueTuple<int, Type>> list = new List<ValueTuple<int, Type>>(num);
			CollectionsMarshal.SetCount<ValueTuple<int, Type>>(list, num);
			Span<ValueTuple<int, Type>> span = CollectionsMarshal.AsSpan<ValueTuple<int, Type>>(list);
			int num2 = 0;
			*span[num2] = new ValueTuple<int, Type>(0, typeof(UUIDynamicBatchMesh));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(1, typeof(UUIItem));
			this.ComponentRegisterInfos = list;
		}

		// Token: 0x06033E96 RID: 212630 RVA: 0x00CFDD04 File Offset: 0x00CFBF04
		protected override UniTask OnBeforeStartAsync()
		{
			TowerDefenseHeadStateDynamicBatchView.<OnBeforeStartAsync>d__9 <OnBeforeStartAsync>d__;
			<OnBeforeStartAsync>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<OnBeforeStartAsync>d__.<>4__this = this;
			<OnBeforeStartAsync>d__.<>1__state = -1;
			<OnBeforeStartAsync>d__.<>t__builder.Start<TowerDefenseHeadStateDynamicBatchView.<OnBeforeStartAsync>d__9>(ref <OnBeforeStartAsync>d__);
			return <OnBeforeStartAsync>d__.<>t__builder.Task;
		}

		// Token: 0x06033E97 RID: 212631 RVA: 0x00CFDD48 File Offset: 0x00CFBF48
		protected override void OnStart()
		{
			this.IsEnable = true;
			this.DynamicBatch = base.GetDynamicBatchMesh(0);
			this.HpParentItem = base.GetItem(1);
			this.HpItem = this.HeadStateView.GetRootItem();
			Vector hpItemWorldPos = this.HpItemWorldPos;
			FVector uiworldPosition = this.HpItem.GetUIWorldPosition();
			hpItemWorldPos.FromUeVector(uiworldPosition);
			this.HpParentItem.SetUIActive(true);
		}

		// Token: 0x06033E98 RID: 212632 RVA: 0x00CFDDAC File Offset: 0x00CFBFAC
		protected override void OnBeforeDestroy()
		{
			this.IsEnable = false;
			if (this.HeadStateView != null)
			{
				this.HeadStateView.Destroy(null);
				this.HeadStateView = null;
			}
		}

		// Token: 0x06033E99 RID: 212633 RVA: 0x00CFDDD0 File Offset: 0x00CFBFD0
		public bool GetIsEnable()
		{
			return this.IsEnable;
		}

		// Token: 0x06033E9A RID: 212634 RVA: 0x00CFDDD8 File Offset: 0x00CFBFD8
		public void RefreshRotation(Rotator cameraRotation)
		{
			this.ActorRotation.Yaw = cameraRotation.Yaw + 90f;
			this.ActorRotation.Roll = cameraRotation.Pitch - 90f;
			this.ActorRotation.Pitch = 0f;
			FHitResult fhitResult = null;
			this.HpParentItem.K2_SetWorldRotation(this.ActorRotation.ToUeRotator(), false, ref fhitResult, true);
		}

		// Token: 0x06033E9B RID: 212635 RVA: 0x00CFDE3F File Offset: 0x00CFC03F
		public void AddToDynamicBatchMesh(TowerDefenseHeadStateData headStateData)
		{
			this.HeadStateView.Refresh(headStateData, this.HpItemWorldPos);
			this.DynamicBatch.AddContainerNode(this.HpItem, true);
		}

		// Token: 0x06033E9C RID: 212636 RVA: 0x00CFDE65 File Offset: 0x00CFC065
		public void ClearDynamicBatchMesh()
		{
			this.DynamicBatch.ClearAllGeometries();
		}

		// Token: 0x0401E05B RID: 122971
		private bool IsEnable;

		// Token: 0x0401E05C RID: 122972
		[Nullable(2)]
		private TowerDefenseHeadStateView HeadStateView;

		// Token: 0x0401E05D RID: 122973
		[Nullable(2)]
		private UUIDynamicBatchMesh DynamicBatch;

		// Token: 0x0401E05E RID: 122974
		[Nullable(2)]
		private UUIItem HpParentItem;

		// Token: 0x0401E05F RID: 122975
		[Nullable(2)]
		private UUIItem HpItem;

		// Token: 0x0401E060 RID: 122976
		private readonly Rotator ActorRotation = Rotator.Create();

		// Token: 0x0401E061 RID: 122977
		private readonly Vector HpItemWorldPos = Vector.Create();

		// Token: 0x0200AE2D RID: 44589
		[NullableContext(0)]
		private enum EChildType
		{
			// Token: 0x0403616E RID: 221550
			UIDynamicBatchMesh,
			// Token: 0x0403616F RID: 221551
			HpContainerItem
		}
	}
}
