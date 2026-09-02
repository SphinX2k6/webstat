using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Aki.Config;
using CSharpScript.Game.Module.Dango.DangoLogic;
using CSharpScript.Game.Module.Util;
using UnrealEngine;

// Token: 0x02002726 RID: 10022
[NullableContext(1)]
[Nullable(new byte[]
{
	0,
	1
})]
public class RacingBetsMatchTableDangoItem : GridProxyAbstract<IRacingBetsMatchTableDangoItemData>
{
	// Token: 0x06013C45 RID: 80965 RVA: 0x0057FD98 File Offset: 0x0057DF98
	protected override void OnRegisterComponent()
	{
		this.ComponentRegisterInfos = new List<ValueTuple<int, Type>>
		{
			new ValueTuple<int, Type>(0, typeof(UUITexture)),
			new ValueTuple<int, Type>(1, typeof(UUIItem)),
			new ValueTuple<int, Type>(2, typeof(UUIItem))
		};
	}

	// Token: 0x06013C46 RID: 80966 RVA: 0x0057FDF2 File Offset: 0x0057DFF2
	protected override void OnBeforeShow()
	{
		this.RootActor.OnSequencePlayEvent.Bind(new Action<string, string>(this.OnSequencePlayEvent));
	}

	// Token: 0x06013C47 RID: 80967 RVA: 0x0057FE10 File Offset: 0x0057E010
	public override void Refresh(IRacingBetsMatchTableDangoItemData data, bool isSelected, int gridIndex)
	{
		bool flag = data.DangoId == 0;
		UUIItem item = base.GetItem(1);
		if (item != null)
		{
			item.SetUIActive(flag);
		}
		UUITexture texture = base.GetTexture(0);
		if (texture != null)
		{
			texture.SetUIActive(!flag);
		}
		if (!flag)
		{
			this.IsNeedPlayLevelSequence = data.IsNeedPlayLevelSequence;
			Dango? dangoById = ConfigBase<DangoConfig>.Instance.GetDangoById(data.DangoId);
			string path = string.Empty;
			UUITexture texture2 = base.GetTexture(0);
			if (data.IsMatchFinished && data.IsPromote)
			{
				path = dangoById.Value.IconAttack;
			}
			if (data.IsMatchFinished && !data.IsPromote)
			{
				path = dangoById.Value.IconDamage;
				if (texture2 != null)
				{
					UUIItem uuiitem = texture2;
					bool bUseChangeColor = true;
					FColor? fcolor = new FColor?(texture2.changeColor);
					uuiitem.SetChangeColor(bUseChangeColor, fcolor);
				}
			}
			if (!data.IsMatchFinished)
			{
				path = (data.IsCurMatch ? dangoById.Value.IconAttack : dangoById.Value.Icon);
			}
			base.SetTextureByPath(path, texture2, null, null);
		}
		UUIItem item2 = base.GetItem(2);
		if (item2 == null)
		{
			return;
		}
		item2.SetUIActive(data.IsNeedCheer && !flag);
	}

	// Token: 0x06013C48 RID: 80968 RVA: 0x0057FF42 File Offset: 0x0057E142
	protected override void OnBeforeHide()
	{
		AUIBaseActor rootActor = this.RootActor;
		if (rootActor == null)
		{
			return;
		}
		rootActor.OnSequencePlayEvent.Unbind();
	}

	// Token: 0x06013C49 RID: 80969 RVA: 0x0057FF59 File Offset: 0x0057E159
	private void OnSequencePlayEvent(string seqName, string eventName)
	{
		if (!this.IsNeedPlayLevelSequence)
		{
			return;
		}
		if (eventName == "Loop")
		{
			this.RootActor.PlayLevelSequenceByKey("Loop");
		}
	}

	// Token: 0x040099EA RID: 39402
	private bool IsNeedPlayLevelSequence;

	// Token: 0x02008ACB RID: 35531
	[NullableContext(0)]
	private class EComponent
	{
		// Token: 0x0402ECB3 RID: 191667
		public const int TextureIcon = 0;

		// Token: 0x0402ECB4 RID: 191668
		public const int ItemEmptyPanel = 1;

		// Token: 0x0402ECB5 RID: 191669
		public const int ItemCheerPanel = 2;
	}
}
