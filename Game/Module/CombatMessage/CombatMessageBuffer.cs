using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Aki.Protocol;
using CSharpScript.Core.Common;
using CSharpScript.Game.Utils;
using Google.Protobuf;

namespace CSharpScript.Game.Module.CombatMessage
{
	// Token: 0x02005E94 RID: 24212
	public class CombatMessageBuffer
	{
		// Token: 0x1700997F RID: 39295
		// (get) Token: 0x0603CE19 RID: 249369 RVA: 0x00F76EE9 File Offset: 0x00F750E9
		public double TimelineOffset
		{
			get
			{
				return this.TimelineOffsetBase + this.Buffer;
			}
		}

		// Token: 0x17009980 RID: 39296
		// (get) Token: 0x0603CE1A RID: 249370 RVA: 0x00F76EF8 File Offset: 0x00F750F8
		public double RemainBufferTime
		{
			get
			{
				return this.LastNotifyExecuteTime - Singleton<Time>.Instance.NowSeconds;
			}
		}

		// Token: 0x0603CE1B RID: 249371 RVA: 0x00F76F0B File Offset: 0x00F7510B
		public CombatMessageBuffer(long creatureDataId)
		{
			this.CreatureDataId = creatureDataId;
		}

		// Token: 0x0603CE1C RID: 249372 RVA: 0x00F76F28 File Offset: 0x00F75128
		[NullableContext(1)]
		public unsafe void AddToQueue(ENotifyMessageId id, [Nullable(2)] Entity entity, CombatCommon combatCommon, IMessage message)
		{
			if (entity == null)
			{
				Log instance = Singleton<Log>.Instance;
				ELogModule module = ELogModule.MultiplayerCombat;
				ELogAuthor author = ELogAuthor.ZQR;
				string message2 = "[CombatMessageModel.Push]失败, entity非法";
				<>y__InlineArray2<ValueTuple<string, object>> <>y__InlineArray = default(<>y__InlineArray2<ValueTuple<string, object>>);
				*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 0) = new ValueTuple<string, object>("CreatureDataId", this.CreatureDataId);
				*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 1) = new ValueTuple<string, object>("id", id);
				instance.Error(module, author, message2, <PrivateImplementationDetails>.InlineArrayAsReadOnlySpan<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(<>y__InlineArray, 2));
				return;
			}
			CharacterCombatMessageComponent characterCombatMessageComponent = (entity != null) ? entity.GetComponent<CharacterCombatMessageComponent>() : null;
			if (characterCombatMessageComponent == null)
			{
				ControllerBase<CombatMessageController>.Instance.Process(id, entity, message, combatCommon);
				return;
			}
			if (id == (ENotifyMessageId)0)
			{
				Log instance2 = Singleton<Log>.Instance;
				ELogModule module2 = ELogModule.MultiplayerCombat;
				ELogAuthor author2 = ELogAuthor.WCL;
				string message3 = "[CombatMessageModel.Push]失败, id非法";
				<>y__InlineArray2<ValueTuple<string, object>> <>y__InlineArray2 = default(<>y__InlineArray2<ValueTuple<string, object>>);
				*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray2, 0) = new ValueTuple<string, object>("CreatureDataId", this.CreatureDataId);
				*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray2, 1) = new ValueTuple<string, object>("id", id);
				instance2.Error(module2, author2, message3, <PrivateImplementationDetails>.InlineArrayAsReadOnlySpan<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(<>y__InlineArray2, 2));
				return;
			}
			float timeStamp = combatCommon.TimeStamp;
			if (timeStamp == 0f)
			{
				Log instance3 = Singleton<Log>.Instance;
				ELogModule module3 = ELogModule.MultiplayerCombat;
				ELogAuthor author3 = ELogAuthor.WCL;
				string message4 = "[CombatMessageModel.Push]失败, messageTime非法";
				<>y__InlineArray3<ValueTuple<string, object>> <>y__InlineArray3 = default(<>y__InlineArray3<ValueTuple<string, object>>);
				*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray3<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray3, 0) = new ValueTuple<string, object>("CreatureDataId", this.CreatureDataId);
				*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray3<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray3, 1) = new ValueTuple<string, object>("id", id);
				*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray3<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray3, 2) = new ValueTuple<string, object>("messageTime", timeStamp);
				instance3.Warn(module3, author3, message4, <PrivateImplementationDetails>.InlineArrayAsReadOnlySpan<<>y__InlineArray3<ValueTuple<string, object>>, ValueTuple<string, object>>(<>y__InlineArray3, 3));
				ControllerBase<CombatMessageController>.Instance.Process(id, entity, message, combatCommon);
				return;
			}
			CreatureDataComponent creatureDataComponent = (entity != null) ? entity.GetComponent<CreatureDataComponent>() : null;
			this.RecordMessageTime((double)timeStamp, creatureDataComponent.GetPbDataId(), false);
			double executeTime = (double)timeStamp + this.TimelineOffset;
			characterCombatMessageComponent.AddToQueue(id, combatCommon, message, executeTime);
		}

		// Token: 0x0603CE1D RID: 249373 RVA: 0x00F770FC File Offset: 0x00F752FC
		public void RecordMessageTime(double messageTime, int pbDataId, bool udpMessage = false)
		{
			double nowSeconds = Singleton<Time>.Instance.NowSeconds;
			if (!udpMessage || nowSeconds - this.LastMessageReceiveTime > 0.20000000298023224)
			{
				this.MessageReceiveTimeQueue.Push(new ValueTuple<double, double>(messageTime, nowSeconds));
				if (this.MessageReceiveTimeQueue.Size >= 20)
				{
					this.MessageReceiveTimeQueue.Pop();
				}
				this.LastMessageReceiveTime = nowSeconds;
			}
			this.RefreshDelayTime();
			double num = messageTime + this.TimelineOffset;
			if (num > this.LastNotifyExecuteTime)
			{
				this.LastNotifyExecuteTime = num;
			}
			this.ReportMoveDataReceiveInfo(nowSeconds - messageTime, pbDataId, udpMessage);
		}

		// Token: 0x0603CE1E RID: 249374 RVA: 0x00F77188 File Offset: 0x00F75388
		private void RefreshDelayTime()
		{
			if (this.MessageReceiveTimeQueue.Size == 0)
			{
				return;
			}
			int i = this.MessageReceiveTimeQueue.Size - 1;
			ValueTuple<double, double> valueTuple = this.MessageReceiveTimeQueue.Get(i);
			double num = valueTuple.Item2 - valueTuple.Item1;
			double num2 = num;
			double item = valueTuple.Item1;
			int num3 = 0;
			while (i > 0)
			{
				num3++;
				double item2 = this.MessageReceiveTimeQueue.Get(i).Item1;
				double item3 = this.MessageReceiveTimeQueue.Get(i).Item2;
				if ((float)num3 > 3f && item - item2 > 5.0)
				{
					break;
				}
				double num4 = item3 - item2;
				if (num > num4)
				{
					num = num4;
				}
				else if (num2 < num4)
				{
					num2 = num4;
				}
				i--;
			}
			double num5 = num2 - num;
			num5 = Singleton<MathUtils>.Instance.Clamp(num5, num5, 0.5);
			this.TimelineOffsetBase = num;
			if (ModelBase<CombatMessageModel>.Instance.MoveSyncUdpMode)
			{
				this.DesiredBuffer = num5 * 1.0499999523162842 + (double)ModelBase<CombatMessageModel>.Instance.MoveSyncUdpSendInterval;
			}
			else
			{
				this.DesiredBuffer = num5 * 1.0499999523162842 + 0.07999999821186066;
			}
			this.RefreshBuffer(0.0);
		}

		// Token: 0x0603CE1F RID: 249375 RVA: 0x00F772C0 File Offset: 0x00F754C0
		private void RefreshBuffer(double increment = 0.0)
		{
			if (this.DesiredBuffer < this.Buffer)
			{
				this.Buffer = Math.Max(this.DesiredBuffer, this.Buffer - increment);
				return;
			}
			if (this.RemainBufferTime > increment)
			{
				this.Buffer = Math.Min(this.DesiredBuffer, this.Buffer + increment);
				return;
			}
			this.Buffer = this.DesiredBuffer;
		}

		// Token: 0x0603CE20 RID: 249376 RVA: 0x00F77324 File Offset: 0x00F75524
		public void OnTick(float delta)
		{
			this.RefreshBuffer((double)(delta * 0.1f));
		}

		// Token: 0x0603CE21 RID: 249377 RVA: 0x00F77334 File Offset: 0x00F75534
		public void ReportMoveDataReceiveInfo(double offset, int pbDataId, bool udpMessage)
		{
			string data = Json.Encode(new Dictionary<string, object>
			{
				{
					"udp_mode",
					ModelBase<CombatMessageModel>.Instance.MoveSyncUdpMode
				},
				{
					"creature_id",
					this.CreatureDataId
				},
				{
					"pb_data_id",
					pbDataId
				},
				{
					"offset",
					offset
				},
				{
					"timeline_offset",
					this.TimelineOffsetBase
				},
				{
					"buffer",
					this.Buffer
				},
				{
					"desired_buffer",
					this.DesiredBuffer
				},
				{
					"remain_buffer",
					this.RemainBufferTime
				},
				{
					"udp_message",
					udpMessage
				}
			}, null);
			ControllerBase<CombatDebugController>.Instance.DataReport("MOVE_SYNC_RECEIVE_INFO", data);
		}

		// Token: 0x040222CA RID: 139978
		public double TimelineOffsetBase;

		// Token: 0x040222CB RID: 139979
		public double DesiredBuffer;

		// Token: 0x040222CC RID: 139980
		public double Buffer;

		// Token: 0x040222CD RID: 139981
		public double LastNotifyExecuteTime;

		// Token: 0x040222CE RID: 139982
		private double LastMessageReceiveTime;

		// Token: 0x040222CF RID: 139983
		[Nullable(new byte[]
		{
			1,
			0
		})]
		private readonly Queue<ValueTuple<double, double>> MessageReceiveTimeQueue = new Queue<ValueTuple<double, double>>(4);

		// Token: 0x040222D0 RID: 139984
		protected long CreatureDataId;
	}
}
