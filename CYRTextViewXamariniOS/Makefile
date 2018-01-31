XBUILD=/Applications/Xcode.app/Contents/Developer/usr/bin/xcodebuild
WORKSPACE=Example/CYRTextViewExample.xcodeproj
WORKSPACE_DIR=CYRTextView
SCHEME=CYRTextViewKit
BUILD_ROOT=build/Build/Products
VALID_ARCHS="armv7 armv7s arm64 x86_64"

all: clean CYRTextViewKit.framework

Podfile.lock:
	git clone https://github.com/illyabusigin/CYRTextView.git

CYRTextViewKit-iphonesimulator: Podfile.lock
	cd $(WORKSPACE_DIR) && $(XBUILD) -project $(WORKSPACE) -scheme $(SCHEME) -sdk iphonesimulator -configuration Release VALID_ARCHS=$(VALID_ARCHS) ENABLE_BITCODE=NO ONLY_ACTIVE_ARCH=NO EFFECTIVE_PLATFORM_NAME="-iphonesimulator" -derivedDataPath build clean build	
	mv $(WORKSPACE_DIR)/$(BUILD_ROOT)/Release-iphonesimulator/CYRTextViewKit.framework/CYRTextViewKit $@

CYRTextViewKit-iphoneos: Podfile.lock
	cd $(WORKSPACE_DIR) && $(XBUILD) -project $(WORKSPACE) -scheme $(SCHEME) -sdk iphoneos -configuration Release ONLY_ACTIVE_ARCH=NO ENABLE_BITCODE=NO -derivedDataPath build clean build
	mv $(WORKSPACE_DIR)/$(BUILD_ROOT)/Release-iphoneos/CYRTextViewKit.framework/CYRTextViewKit $@
	cp -R $(WORKSPACE_DIR)/$(BUILD_ROOT)/Release-iphoneos/CYRTextViewKit.framework CYRTextViewKit.framework

CYRTextViewKit.framework: CYRTextViewKit-iphoneos CYRTextViewKit-iphonesimulator
	lipo -create -output $@/CYRTextViewKit $^	

clean:
	rm -rf CYRTextView

.PHONY: all clean