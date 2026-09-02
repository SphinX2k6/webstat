using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using Aki.Config;
using Cysharp.Threading.Tasks;
using UnrealEngine;

namespace CSharpScript.Game.Module.BattleUi.Views
{
	// Token: 0x02006091 RID: 24721
	public class RoleBuffView : BattleVisibleChildView
	{
		// Token: 0x0603E60F RID: 255503 RVA: 0x00FEE624 File Offset: 0x00FEC824
		protected unsafe override void OnRegisterComponent()
		{
			int num = 2;
			List<ValueTuple<int, Type>> list = new List<ValueTuple<int, Type>>(num);
			CollectionsMarshal.SetCount<ValueTuple<int, Type>>(list, num);
			Span<ValueTuple<int, Type>> span = CollectionsMarshal.AsSpan<ValueTuple<int, Type>>(list);
			int num2 = 0;
			*span[num2] = new ValueTuple<int, Type>(0, typeof(UUIItem));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(1, typeof(UUIItem));
			this.ComponentRegisterInfos = list;
		}

		// Token: 0x0603E610 RID: 255504 RVA: 0x00FEE690 File Offset: 0x00FEC890
		protected override void OnStart()
		{
			base.OnStart();
			base.InitChildType(EBattleUiChild.Ignore);
			this.InitExceedTipItem();
			int value = ConfigCommonParamById.GetIntConfig("RoleBuffItemCount").Value;
			this.BuffItemContainer.Init(base.GetItem(1), value, false, true, false, this.ExceedTipItem.GetRootItem());
		}

		// Token: 0x0603E611 RID: 255505 RVA: 0x00FEE6E5 File Offset: 0x00FEC8E5
		protected override void OnBeforeDestroy()
		{
			this.Refresh(null);
			this.ClearAllEnvironmentItem();
			this.DestroyExceedTipItem();
		}

		// Token: 0x0603E612 RID: 255506 RVA: 0x00FEE6FA File Offset: 0x00FEC8FA
		private void InitExceedTipItem()
		{
			this.ExceedTipItem = new BuffItem(base.GetItem(1));
			this.ExceedTipItem.ActivateExceedTip();
		}

		// Token: 0x0603E613 RID: 255507 RVA: 0x00FEE719 File Offset: 0x00FEC919
		private void DestroyExceedTipItem()
		{
			if (this.ExceedTipItem != null)
			{
				this.ExceedTipItem.DestroyCompatible();
				this.ExceedTipItem = null;
			}
		}

		// Token: 0x0603E614 RID: 255508 RVA: 0x00FEE738 File Offset: 0x00FEC938
		[NullableContext(2)]
		public void Refresh(BattleUiRoleData roleData)
		{
			if (roleData == null)
			{
				this.EntityId = null;
				this.BuffItemContainer.ClearAll();
				return;
			}
			EntityHandle entityHandle = roleData.EntityHandle;
			this.EntityId = ((entityHandle != null) ? new int?(entityHandle.Id) : null);
			this.BuffItemContainer.RefreshBuff(roleData.EntityHandle);
		}

		// Token: 0x0603E615 RID: 255509 RVA: 0x00FEE796 File Offset: 0x00FEC996
		public int? GetEntityId()
		{
			return this.EntityId;
		}

		// Token: 0x0603E616 RID: 255510 RVA: 0x00FEE79E File Offset: 0x00FEC99E
		public void Tick(float delta)
		{
			this.BuffItemContainer.Tick(delta);
			this.UpdateEnvironmentProperty();
		}

		// Token: 0x0603E617 RID: 255511 RVA: 0x00FEE7B2 File Offset: 0x00FEC9B2
		public void AddBuff(GameplayCue buffCueConfig, int handleId)
		{
			this.BuffItemContainer.AddBuffByCue(buffCueConfig, handleId, true);
		}

		// Token: 0x0603E618 RID: 255512 RVA: 0x00FEE7C2 File Offset: 0x00FEC9C2
		public void RemoveBuff(GameplayCue buffCueConfig, int handleId)
		{
			this.BuffItemContainer.RemoveBuffByCue(buffCueConfig, handleId, true);
		}

		// Token: 0x0603E619 RID: 255513 RVA: 0x00FEE7D4 File Offset: 0x00FEC9D4
		private void UpdateEnvironmentProperty()
		{
			float num = 0f;
			foreach (int num2 in ModelBase<BattleUiModel>.Instance.FormationData.EnvironmentPropertyList)
			{
				float value = ModelBase<FormationAttributeModel>.Instance.GetValue((EFormationAttributeId)num2);
				if (value > num)
				{
					num = value;
				}
				EnvironmentItem environmentItem = this.EnvironmentItemMap.GetValueOrDefault(num2);
				if (environmentItem == null)
				{
					if (value > 0f)
					{
						UUIItem item = base.GetItem(0);
						AActor environmentItem2 = ControllerBase<BattleUiControl>.Instance.Pool.GetEnvironmentItem(item);
						environmentItem = new EnvironmentItem();
						environmentItem.InitPropertyId(num2);
						float max = ModelBase<FormationAttributeModel>.Instance.GetMax((EFormationAttributeId)num2);
						environmentItem.SetPercent(value, max);
						environmentItem.CreateThenShowByActorAsync(environmentItem2, null, false).Forget();
						this.EnvironmentItemMap[num2] = environmentItem;
					}
				}
				else
				{
					float max2 = ModelBase<FormationAttributeModel>.Instance.GetMax((EFormationAttributeId)num2);
					environmentItem.SetPercent(value, max2);
				}
			}
		}

		// Token: 0x0603E61A RID: 255514 RVA: 0x00FEE8DC File Offset: 0x00FECADC
		private void ClearAllEnvironmentItem()
		{
			foreach (EnvironmentItem environmentItem in this.EnvironmentItemMap.Values)
			{
				ControllerBase<BattleUiControl>.Instance.Pool.RecycleEnvironmentItem(environmentItem.GetRootActor());
				environmentItem.Destroy(null);
			}
			this.EnvironmentItemMap.Clear();
		}

		// Token: 0x04022F50 RID: 143184
		private int? EntityId;

		// Token: 0x04022F51 RID: 143185
		[Nullable(1)]
		private readonly Dictionary<int, EnvironmentItem> EnvironmentItemMap = new Dictionary<int, EnvironmentItem>();

		// Token: 0x04022F52 RID: 143186
		[Nullable(1)]
		private readonly BuffItemContainer BuffItemContainer = new BuffItemContainer();

		// Token: 0x04022F53 RID: 143187
		[Nullable(2)]
		private BuffItem ExceedTipItem;

		// Token: 0x0200C181 RID: 49537
		private enum EChildComponentType
		{
			// Token: 0x0403B965 RID: 244069
			EnvironmentHorizontalItem,
			// Token: 0x0403B966 RID: 244070
			BuffHorizontalItem
		}
	}
}
