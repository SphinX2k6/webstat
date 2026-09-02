using System;

// Token: 0x02000030 RID: 48
public enum ECallbackMask
{
	// Token: 0x0400009F RID: 159
	EndOfEvent = 1,
	// Token: 0x040000A0 RID: 160
	Marker = 4,
	// Token: 0x040000A1 RID: 161
	Duration = 8,
	// Token: 0x040000A2 RID: 162
	Starvation = 32,
	// Token: 0x040000A3 RID: 163
	MusicPlayStarted = 128,
	// Token: 0x040000A4 RID: 164
	MusicSyncBeat = 256,
	// Token: 0x040000A5 RID: 165
	MusicSyncBar = 512,
	// Token: 0x040000A6 RID: 166
	MusicSyncEntry = 1024,
	// Token: 0x040000A7 RID: 167
	MusicSyncExit = 2048,
	// Token: 0x040000A8 RID: 168
	MusicSyncGrid = 4096,
	// Token: 0x040000A9 RID: 169
	MusicSyncUserCue = 8192,
	// Token: 0x040000AA RID: 170
	MusicSyncPoint = 16384,
	// Token: 0x040000AB RID: 171
	MIDIEvent = 32768,
	// Token: 0x040000AC RID: 172
	EnableGetSourcePlayPosition = 0
}
