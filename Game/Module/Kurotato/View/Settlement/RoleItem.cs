using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using Aki.Config;
using CSharpScript.Game.Module.Skin;
using UnrealEngine;

namespace CSharpScript.Game.Module.Kurotato.View.Settlement
{
	// Token: 0x02005A81 RID: 23169
	internal class RoleItem : SyncGridProxyAbstract<int>
	{
		// Token: 0x0603A9FD RID: 240125 RVA: 0x00ED9D88 File Offset: 0x00ED7F88
		protected unsafe override void OnRegisterComponent()
		{
			int num = 3;
			List<ValueTuple<int, Type>> list = new List<ValueTuple<int, Type>>(num);
			CollectionsMarshal.SetCount<ValueTuple<int, Type>>(list, num);
			Span<ValueTuple<int, Type>> span = CollectionsMarshal.AsSpan<ValueTuple<int, Type>>(list);
			int num2 = 0;
			*span[num2] = new ValueTuple<int, Type>(0, typeof(UUIButtonComponent));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(1, typeof(UUITexture));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(2, typeof(UUIText));
			this.ComponentRegisterInfos = list;
			num2 = 1;
			List<ValueTuple<int, Delegate>> list2 = new List<ValueTuple<int, Delegate>>(num2);
			CollectionsMarshal.SetCount<ValueTuple<int, Delegate>>(list2, num2);
			Span<ValueTuple<int, Delegate>> span2 = CollectionsMarshal.AsSpan<ValueTuple<int, Delegate>>(list2);
			num = 0;
			*span2[num] = new ValueTuple<int, Delegate>(0, new Action(this.OnClickBtn));
			this.BtnBindInfo = list2;
		}

		// Token: 0x0603A9FE RID: 240126 RVA: 0x00ED9E4F File Offset: 0x00ED804F
		protected override void OnStart()
		{
		}

		// Token: 0x0603A9FF RID: 240127 RVA: 0x00ED9E54 File Offset: 0x00ED8054
		public override void Refresh(int data)
		{
			this.Data = data;
			KurotatoCharacter value = ConfigBase<KurotatoConfig>.Instance.GetCharacterById(data).Value;
			RoleDataBase roleDataByKurotatoRoleId = ModelBase<KurotatoModel>.Instance.GetRoleDataByKurotatoRoleId(data);
			base.SetTextureByPath(ConfigBase<SkinConfig>.Instance.GetRoleSkinConfig(roleDataByKurotatoRoleId.GetRoleSkinId()).Value.RoleHeadIconLarge, base.GetTexture(1), null, null);
			base.GetText(2).ShowTextNew(value.Name);
		}

		// Token: 0x0603AA00 RID: 240128 RVA: 0x00ED9ED4 File Offset: 0x00ED80D4
		private void OnClickBtn()
		{
			Action<int> onClickCb = this.OnClickCb;
			if (onClickCb == null)
			{
				return;
			}
			onClickCb(this.Data);
		}

		// Token: 0x04021298 RID: 135832
		public int Data;

		// Token: 0x04021299 RID: 135833
		[Nullable(1)]
		public Action<int> OnClickCb;

		// Token: 0x0200BA55 RID: 47701
		private class ERoleComps
		{
			// Token: 0x04039890 RID: 235664
			public const int Btn = 0;

			// Token: 0x04039891 RID: 235665
			public const int TextureRole = 1;

			// Token: 0x04039892 RID: 235666
			public const int TextName = 2;
		}
	}
}
