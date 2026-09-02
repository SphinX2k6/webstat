using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using AkiClient.Game.Aki.Data.Level.AttachMove;
using UnrealEngine;

namespace CSharpScript.Game.NewWorld.Character.Common.Component.Move.AttachMove
{
	// Token: 0x0200493C RID: 18748
	[NullableContext(1)]
	[Nullable(0)]
	public class AttachMoveParams
	{
		// Token: 0x06031060 RID: 200800 RVA: 0x00C2F0D0 File Offset: 0x00C2D2D0
		[NullableContext(2)]
		public AttachMoveParams(BP_AttachMoveConfig_C data = null)
		{
			if (data == null)
			{
				return;
			}
			this.Debug = data.Debug;
			this.AttachSocket = data.AttachSocket;
			Transform attachTransform = this.AttachTransform;
			FTransform attachTransform2 = data.AttachTransform;
			attachTransform.FromUeTransform(attachTransform2);
			for (int i = 0; i < data.GameplayTagList.GameplayTags.Num(); i++)
			{
				this.GameplayTagList.Add(data.GameplayTagList.GameplayTags.Get(i).TagId());
			}
		}

		// Token: 0x0401C387 RID: 115591
		public bool Debug;

		// Token: 0x0401C388 RID: 115592
		public List<int> GameplayTagList = new List<int>();

		// Token: 0x0401C389 RID: 115593
		public string AttachSocket = "";

		// Token: 0x0401C38A RID: 115594
		public Transform AttachTransform = Transform.Create();
	}
}
