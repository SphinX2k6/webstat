using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using CSharpScript.Game.Module.RoleUi;
using CSharpScript.Game.Ui;
using Cysharp.Threading.Tasks;
using UnrealEngine;

namespace CSharpScript.Game.Module.Activity.ActivityContent.Fishing
{
	// Token: 0x020067D4 RID: 26580
	public class FishingRoleTalkPanel : UiPanelBase
	{
		// Token: 0x060424E3 RID: 271587 RVA: 0x0110213C File Offset: 0x0110033C
		protected unsafe override void OnRegisterComponent()
		{
			int num = 2;
			List<ValueTuple<int, Type>> list = new List<ValueTuple<int, Type>>(num);
			CollectionsMarshal.SetCount<ValueTuple<int, Type>>(list, num);
			Span<ValueTuple<int, Type>> span = CollectionsMarshal.AsSpan<ValueTuple<int, Type>>(list);
			int num2 = 0;
			*span[num2] = new ValueTuple<int, Type>(0, typeof(UUITexture));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(1, typeof(UUIText));
			this.ComponentRegisterInfos = list;
		}

		// Token: 0x060424E4 RID: 271588 RVA: 0x011021A5 File Offset: 0x011003A5
		protected override void OnStart()
		{
			this.LevelSequencePlayer = new LevelSequencePlayer(this.RootItem);
		}

		// Token: 0x060424E5 RID: 271589 RVA: 0x011021B8 File Offset: 0x011003B8
		public void SetRoleHead(int roleId)
		{
			base.SetRoleIcon(ConfigBase<RoleConfig>.Instance.GetRoleConfig(roleId).Value.RoleHeadIconCircle, base.GetTexture(0), roleId, null, null);
		}

		// Token: 0x060424E6 RID: 271590 RVA: 0x011021F8 File Offset: 0x011003F8
		[NullableContext(1)]
		public void SetTxtInfo(string textId, params object[] args)
		{
			Singleton<LguiUtil>.Instance.SetLocalTextNew(base.GetText(1), textId, args);
		}

		// Token: 0x060424E7 RID: 271591 RVA: 0x01102210 File Offset: 0x01100410
		[NullableContext(1)]
		public void PlayAnim(string sequenceName, [Nullable(2)] Action callback = null)
		{
			CustomPromise<bool> stopPromise = new CustomPromise<bool>();
			this.LevelSequencePlayer.PlaySequenceAsync(sequenceName, stopPromise, false, false, null, false).ContinueWith(delegate()
			{
				Action callback2 = callback;
				if (callback2 == null)
				{
					return;
				}
				callback2();
			});
		}

		// Token: 0x04024E94 RID: 151188
		[Nullable(2)]
		protected LevelSequencePlayer LevelSequencePlayer;

		// Token: 0x0200C822 RID: 51234
		private class EComponentDefine
		{
			// Token: 0x0403D96D RID: 252269
			public const int TexRoleHead = 0;

			// Token: 0x0403D96E RID: 252270
			public const int TxtInfo = 1;
		}
	}
}
