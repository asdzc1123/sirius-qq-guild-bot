package native

import (
	"syscall"
	"unsafe"
)

func Call(addr uintptr, a ...uintptr) (r1, r2 uintptr, lastErr error) {
	switch len(a) {
	case 0:
		return syscall.Syscall(addr, uintptr(len(a)), 0, 0, 0)
	case 1:
		return syscall.Syscall(addr, uintptr(len(a)), a[0], 0, 0)
	case 2:
		return syscall.Syscall(addr, uintptr(len(a)), a[0], a[1], 0)
	case 3:
		return syscall.Syscall(addr, uintptr(len(a)), a[0], a[1], a[2])
	case 4:
		return syscall.Syscall6(addr, uintptr(len(a)), a[0], a[1], a[2], a[3], 0, 0)
	case 5:
		return syscall.Syscall6(addr, uintptr(len(a)), a[0], a[1], a[2], a[3], a[4], 0)
	case 6:
		return syscall.Syscall6(addr, uintptr(len(a)), a[0], a[1], a[2], a[3], a[4], a[5])
	case 7:
		return syscall.Syscall9(addr, uintptr(len(a)), a[0], a[1], a[2], a[3], a[4], a[5], a[6], 0, 0)
	case 8:
		return syscall.Syscall9(addr, uintptr(len(a)), a[0], a[1], a[2], a[3], a[4], a[5], a[6], a[7], 0)
	case 9:
		return syscall.Syscall9(addr, uintptr(len(a)), a[0], a[1], a[2], a[3], a[4], a[5], a[6], a[7], a[8])
	case 10:
		return syscall.Syscall12(addr, uintptr(len(a)), a[0], a[1], a[2], a[3], a[4], a[5], a[6], a[7], a[8], a[9], 0, 0)
	case 11:
		return syscall.Syscall12(addr, uintptr(len(a)), a[0], a[1], a[2], a[3], a[4], a[5], a[6], a[7], a[8], a[9], a[10], 0)
	case 12:
		return syscall.Syscall12(addr, uintptr(len(a)), a[0], a[1], a[2], a[3], a[4], a[5], a[6], a[7], a[8], a[9], a[10], a[11])
	case 13:
		return syscall.Syscall15(addr, uintptr(len(a)), a[0], a[1], a[2], a[3], a[4], a[5], a[6], a[7], a[8], a[9], a[10], a[11], a[12], 0, 0)
	case 14:
		return syscall.Syscall15(addr, uintptr(len(a)), a[0], a[1], a[2], a[3], a[4], a[5], a[6], a[7], a[8], a[9], a[10], a[11], a[12], a[13], 0)
	case 15:
		return syscall.Syscall15(addr, uintptr(len(a)), a[0], a[1], a[2], a[3], a[4], a[5], a[6], a[7], a[8], a[9], a[10], a[11], a[12], a[13], a[14])
	case 16:
		return syscall.Syscall18(addr, uintptr(len(a)), a[0], a[1], a[2], a[3], a[4], a[5], a[6], a[7], a[8], a[9], a[10], a[11], a[12], a[13], a[14], a[15], 0, 0)
	case 17:
		return syscall.Syscall18(addr, uintptr(len(a)), a[0], a[1], a[2], a[3], a[4], a[5], a[6], a[7], a[8], a[9], a[10], a[11], a[12], a[13], a[14], a[15], a[16], 0)
	case 18:
		return syscall.Syscall18(addr, uintptr(len(a)), a[0], a[1], a[2], a[3], a[4], a[5], a[6], a[7], a[8], a[9], a[10], a[11], a[12], a[13], a[14], a[15], a[16], a[17])
	default:
		panic("Call  with too many arguments ")
	}
}

func StringPtr(s string) uintptr {
	return uintptr(unsafe.Pointer(&[]byte(s)[0]))
}

func IntPtr(i int) uintptr {
	return uintptr(i)
}

func BytesStringPtr(s []byte) uintptr {
	return uintptr(unsafe.Pointer(&(s)[0]))
}

// DeepCopyString 深拷贝外部GC管理的字符串
func DeepCopyString(notGoString string) string {
	var notGoBytes = []byte(notGoString)

	var goBytes = make([]byte, len(notGoBytes))
	copy(goBytes, notGoBytes)
	return string(goBytes)
}

