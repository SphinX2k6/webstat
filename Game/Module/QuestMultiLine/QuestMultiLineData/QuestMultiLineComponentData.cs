using System;
using System.Runtime.CompilerServices;
using Aki.Config;

namespace CSharpScript.Game.Module.QuestMultiLine.QuestMultiLineData
{
	// Token: 0x02005345 RID: 21317
	[NullableContext(1)]
	[Nullable(0)]
	public class QuestMultiLineComponentData
	{
		// Token: 0x060365E8 RID: 222696 RVA: 0x00DB5294 File Offset: 0x00DB3494
		public QuestMultiLineComponentData(int configId)
		{
			this.Config = QuestMultiLineConfig.GetComponentConfigById(configId);
		}

		// Token: 0x17008D39 RID: 36153
		// (get) Token: 0x060365E9 RID: 222697 RVA: 0x00DB52A8 File Offset: 0x00DB34A8
		public int Id
		{
			get
			{
				return this.Config.Value.Id;
			}
		}

		// Token: 0x17008D3A RID: 36154
		// (get) Token: 0x060365EA RID: 222698 RVA: 0x00DB52C8 File Offset: 0x00DB34C8
		public IntVector2D? Location
		{
			get
			{
				return this.Config.Value.Location;
			}
		}

		// Token: 0x17008D3B RID: 36155
		// (get) Token: 0x060365EB RID: 222699 RVA: 0x00DB52E8 File Offset: 0x00DB34E8
		public string TipsTitle
		{
			get
			{
				return this.Config.Value.TipsTitle;
			}
		}

		// Token: 0x17008D3C RID: 36156
		// (get) Token: 0x060365EC RID: 222700 RVA: 0x00DB5308 File Offset: 0x00DB3508
		public string TipsDesc
		{
			get
			{
				return this.Config.Value.TipsDesc;
			}
		}

		// Token: 0x17008D3D RID: 36157
		// (get) Token: 0x060365ED RID: 222701 RVA: 0x00DB5328 File Offset: 0x00DB3528
		public int Type
		{
			get
			{
				return this.Config.Value.Type;
			}
		}

		// Token: 0x17008D3E RID: 36158
		// (get) Token: 0x060365EE RID: 222702 RVA: 0x00DB5348 File Offset: 0x00DB3548
		public int FightingArea
		{
			get
			{
				return this.Config.Value.Location.Value.X;
			}
		}

		// Token: 0x17008D3F RID: 36159
		// (get) Token: 0x060365EF RID: 222703 RVA: 0x00DB5378 File Offset: 0x00DB3578
		public int StatusType
		{
			get
			{
				return this.Config.Value.StatusType;
			}
		}

		// Token: 0x17008D40 RID: 36160
		// (get) Token: 0x060365F0 RID: 222704 RVA: 0x00DB5398 File Offset: 0x00DB3598
		public string[] ComponentIcon
		{
			get
			{
				return this.Config.Value.ComponentIcon();
			}
		}

		// Token: 0x17008D41 RID: 36161
		// (get) Token: 0x060365F1 RID: 222705 RVA: 0x00DB53B8 File Offset: 0x00DB35B8
		public string[] MultiPersonAvatar
		{
			get
			{
				return this.Config.Value.MultiPersonAvatar();
			}
		}

		// Token: 0x17008D42 RID: 36162
		// (get) Token: 0x060365F2 RID: 222706 RVA: 0x00DB53D8 File Offset: 0x00DB35D8
		public string TipsArea
		{
			get
			{
				return this.Config.Value.TipsArea;
			}
		}

		// Token: 0x17008D43 RID: 36163
		// (get) Token: 0x060365F3 RID: 222707 RVA: 0x00DB53F8 File Offset: 0x00DB35F8
		public string TipsStatusDesc
		{
			get
			{
				return this.Config.Value.TipsStatusDesc;
			}
		}

		// Token: 0x17008D44 RID: 36164
		// (get) Token: 0x060365F4 RID: 222708 RVA: 0x00DB5418 File Offset: 0x00DB3618
		public int[] BranchFinishQuestNode
		{
			get
			{
				return this.Config.Value.BranchFinishQuestNode();
			}
		}

		// Token: 0x17008D45 RID: 36165
		// (get) Token: 0x060365F5 RID: 222709 RVA: 0x00DB5438 File Offset: 0x00DB3638
		public string OnGoingDesc
		{
			get
			{
				return this.Config.Value.OnGoingDesc;
			}
		}

		// Token: 0x17008D46 RID: 36166
		// (get) Token: 0x060365F6 RID: 222710 RVA: 0x00DB5458 File Offset: 0x00DB3658
		public string ComponentQualityFrame
		{
			get
			{
				return this.Config.Value.ComponentQualityFrame;
			}
		}

		// Token: 0x17008D47 RID: 36167
		// (get) Token: 0x060365F7 RID: 222711 RVA: 0x00DB5478 File Offset: 0x00DB3678
		public string ComponentQualityFrameHold
		{
			get
			{
				return this.Config.Value.ComponentQualityFrameHold;
			}
		}

		// Token: 0x17008D48 RID: 36168
		// (get) Token: 0x060365F8 RID: 222712 RVA: 0x00DB5498 File Offset: 0x00DB3698
		public string HeadIconBgInTip
		{
			get
			{
				return this.Config.Value.HeadIconBgInTip;
			}
		}

		// Token: 0x17008D49 RID: 36169
		// (get) Token: 0x060365F9 RID: 222713 RVA: 0x00DB54B8 File Offset: 0x00DB36B8
		public string TipsQualityBg
		{
			get
			{
				return this.Config.Value.TipsQualityBg;
			}
		}

		// Token: 0x17008D4A RID: 36170
		// (get) Token: 0x060365FA RID: 222714 RVA: 0x00DB54D8 File Offset: 0x00DB36D8
		public IntVector2D[] AnimMovePoint
		{
			get
			{
				return this.Config.Value.AnimMovePoint();
			}
		}

		// Token: 0x17008D4B RID: 36171
		// (get) Token: 0x060365FB RID: 222715 RVA: 0x00DB54F8 File Offset: 0x00DB36F8
		public int MoveSpeed
		{
			get
			{
				return this.Config.Value.MoveSpeed;
			}
		}

		// Token: 0x17008D4C RID: 36172
		// (get) Token: 0x060365FC RID: 222716 RVA: 0x00DB5518 File Offset: 0x00DB3718
		public int PathSpeed
		{
			get
			{
				return this.Config.Value.PathSpeed;
			}
		}

		// Token: 0x17008D4D RID: 36173
		// (get) Token: 0x060365FD RID: 222717 RVA: 0x00DB5538 File Offset: 0x00DB3738
		public string HeadLoopEffect
		{
			get
			{
				return this.Config.Value.HeadLoopEffect;
			}
		}

		// Token: 0x0401F457 RID: 128087
		private readonly QuestTimeComponentConfig? Config;
	}
}
