using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using CSharpScript.Game.Module.RoleUi;
using CSharpScript.Game.Module.Util;
using UnrealEngine;

namespace CSharpScript.Game.Module.BossPiling.View.Item
{
	// Token: 0x02005F10 RID: 24336
	[NullableContext(1)]
	[Nullable(new byte[]
	{
		0,
		1
	})]
	public class BossPilingRoleItem : GridProxyAbstract<BossPilingTeamRoleInfo>
	{
		// Token: 0x0603D1D8 RID: 250328 RVA: 0x00F86A54 File Offset: 0x00F84C54
		protected unsafe override void OnRegisterComponent()
		{
			int num = 4;
			List<ValueTuple<int, Type>> list = new List<ValueTuple<int, Type>>(num);
			CollectionsMarshal.SetCount<ValueTuple<int, Type>>(list, num);
			Span<ValueTuple<int, Type>> span = CollectionsMarshal.AsSpan<ValueTuple<int, Type>>(list);
			int num2 = 0;
			*span[num2] = new ValueTuple<int, Type>(0, typeof(UUIButtonComponent));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(1, typeof(UUISprite));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(2, typeof(UUITexture));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(3, typeof(UUISprite));
			this.ComponentRegisterInfos = list;
			num2 = 1;
			List<ValueTuple<int, Delegate>> list2 = new List<ValueTuple<int, Delegate>>(num2);
			CollectionsMarshal.SetCount<ValueTuple<int, Delegate>>(list2, num2);
			Span<ValueTuple<int, Delegate>> span2 = CollectionsMarshal.AsSpan<ValueTuple<int, Delegate>>(list2);
			num = 0;
			*span2[num] = new ValueTuple<int, Delegate>(0, new Action(this.OnClicked));
			this.BtnBindInfo = list2;
		}

		// Token: 0x0603D1D9 RID: 250329 RVA: 0x00F86B3C File Offset: 0x00F84D3C
		public override void Refresh(BossPilingTeamRoleInfo data, bool isSelected, int gridIndex)
		{
			this.RoleId = data.RoleId;
			UUISprite sprite = base.GetSprite(1);
			if (sprite != null)
			{
				sprite.SetUIActive(this.RoleId == 0);
			}
			UUITexture texture = base.GetTexture(2);
			if (texture != null)
			{
				texture.SetUIActive(this.RoleId != 0);
			}
			if (this.RoleId != 0)
			{
				if (ConfigBase<RoleConfig>.Instance.IsTrialRole(this.RoleId))
				{
					base.SetRoleIcon("", base.GetTexture(2), this.RoleId, null, null);
				}
				else
				{
					RoleDataBase roleDataById = ModelBase<RoleModel>.Instance.GetRoleDataById(this.RoleId, true);
					base.SetRoleIconByRoleIdOrSkinId("", base.GetTexture(2), this.RoleId, new int?(roleDataById.GetRoleSkinId()), null, null);
				}
				bool flag = ModelBase<RoleModel>.Instance.IsRoleHasBranch(this.RoleId);
				UUISprite sprite2 = base.GetSprite(3);
				if (sprite2 != null)
				{
					sprite2.SetUIActive(flag);
				}
				if (flag)
				{
					int roleBranchIndexById = ModelBase<RoleModel>.Instance.GetRoleBranchIndexById(this.RoleId, data.TagId);
					this.TagRotation.Yaw = (float)((roleBranchIndexById == 0) ? 0 : 180);
					UUISprite sprite3 = base.GetSprite(3);
					if (sprite3 == null)
					{
						return;
					}
					FRotator frotator = this.TagRotation.ToUeRotator();
					sprite3.SetUIRelativeRotation(frotator);
				}
				return;
			}
			UUISprite sprite4 = base.GetSprite(3);
			if (sprite4 == null)
			{
				return;
			}
			sprite4.SetUIActive(false);
		}

		// Token: 0x0603D1DA RID: 250330 RVA: 0x00F86C90 File Offset: 0x00F84E90
		private void OnClicked()
		{
			Action<int, int> onClickedCb = this.OnClickedCb;
			if (onClickedCb == null)
			{
				return;
			}
			onClickedCb(this.RoleId, base.GridIndex);
		}

		// Token: 0x04022460 RID: 140384
		protected int RoleId;

		// Token: 0x04022461 RID: 140385
		[Nullable(2)]
		public Action<int, int> OnClickedCb;

		// Token: 0x04022462 RID: 140386
		private readonly Rotator TagRotation = Rotator.Create();

		// Token: 0x0200BF10 RID: 48912
		[NullableContext(0)]
		private enum ERole
		{
			// Token: 0x0403ACF5 RID: 240885
			Btn,
			// Token: 0x0403ACF6 RID: 240886
			SpriteIcon,
			// Token: 0x0403ACF7 RID: 240887
			TexRole,
			// Token: 0x0403ACF8 RID: 240888
			SpriteTag
		}
	}
}
