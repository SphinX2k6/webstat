using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using CSharpScript.Game.Module.Util;
using UnrealEngine;

namespace CSharpScript.Game.Module.FlagChallenge
{
	// Token: 0x02005D63 RID: 23907
	[NullableContext(1)]
	[Nullable(new byte[]
	{
		0,
		1
	})]
	public class FlagChallengeFormationRoleItem : GridProxyAbstract<IFlagChallengeFormationRoleItemData>
	{
		// Token: 0x0603C3D1 RID: 246737 RVA: 0x00F47ACC File Offset: 0x00F45CCC
		protected override void OnRegisterComponent()
		{
			this.ComponentRegisterInfos = new List<ValueTuple<int, Type>>
			{
				new ValueTuple<int, Type>(0, typeof(UUIButtonComponent)),
				new ValueTuple<int, Type>(1, typeof(UUISprite)),
				new ValueTuple<int, Type>(2, typeof(UUITexture))
			};
			this.BtnBindInfo = new List<ValueTuple<int, Delegate>>
			{
				new ValueTuple<int, Delegate>(0, new Action(this.OnClickButton))
			};
		}

		// Token: 0x0603C3D2 RID: 246738 RVA: 0x00F47B4C File Offset: 0x00F45D4C
		public override void Refresh(IFlagChallengeFormationRoleItemData data, bool isSelected, int gridIndex)
		{
			this.Data = data;
			RoleDataBase roleData = data.RoleData;
			UUITexture roleIconTex = base.GetTexture(2);
			roleIconTex.SetUIActive(false);
			if (roleData != null)
			{
				base.SetRoleIcon(roleData.GetRoleConfig().RoleHeadIconCircle, roleIconTex, roleData.GetRoleId(), null, delegate(bool _)
				{
					roleIconTex.SetUIActive(true);
				});
			}
		}

		// Token: 0x0603C3D3 RID: 246739 RVA: 0x00F47BBE File Offset: 0x00F45DBE
		public void SetClickCallback(Action<int> callback)
		{
			this.ClickCallback = callback;
		}

		// Token: 0x0603C3D4 RID: 246740 RVA: 0x00F47BC7 File Offset: 0x00F45DC7
		private void OnClickButton()
		{
			if (this.Data == null || this.Data.RoleData == null)
			{
				return;
			}
			Action<int> clickCallback = this.ClickCallback;
			if (clickCallback == null)
			{
				return;
			}
			clickCallback(this.Data.RoleData.GetDataId());
		}

		// Token: 0x04021D88 RID: 138632
		[Nullable(2)]
		private IFlagChallengeFormationRoleItemData Data;

		// Token: 0x04021D89 RID: 138633
		[Nullable(2)]
		private Action<int> ClickCallback;
	}
}
